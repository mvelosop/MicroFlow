using Microsoft.Extensions.Configuration;
using System.IO;

namespace MicroFlow.Setup
{
	public class TestConfiguration
	{
		public IConfigurationRoot Setup()
		{
			return new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddEnvironmentVariables()
				.Build();
		}
	}
}