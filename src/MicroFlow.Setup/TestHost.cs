using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MicroFlow.Setup
{
	public class TestHost
	{
		private readonly Startup _startup;

		public TestHost()
		{
			var services = new ServiceCollection();

			Configuration = new TestConfiguration().Setup();

			_startup = new Startup(Configuration);

			_startup.ConfigureServices(services);

			ApplicationServices = services.BuildServiceProvider();
		}

		public IServiceProvider ApplicationServices { get; }

		public IConfigurationRoot Configuration { get; }

		public IServiceScope CreateScope()
		{
			return ApplicationServices.CreateScope();
		}

		public void Run()
		{
			_startup.SetupDatabase(ApplicationServices);
		}
	}
}