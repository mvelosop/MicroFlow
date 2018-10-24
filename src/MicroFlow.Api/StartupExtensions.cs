using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroFlow.Api
{
	public static class StartupExtensions
	{
		public static void AddMicroFlow(this IServiceCollection services, IConfiguration configuration)
		{
			var appStartup = new Setup.Startup(configuration);

			appStartup.ConfigureServices(services);
		}
	}
}