using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using NJsonSchema;
using NSwag.AspNetCore;
using System;

namespace MicroFlow.Api
{
	public class Startup
	{
		private readonly Setup.Startup _appStartup;

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
			_appStartup = new Setup.Startup(configuration);
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider appServices)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();

			// Register the Swagger generator and the Swagger UI middlewares
			app.UseSwaggerUi3WithApiExplorer(settings =>
			{
				settings.GeneratorSettings.DefaultPropertyNameHandling =
					PropertyNameHandling.CamelCase;

				settings.GeneratorSettings.DefaultEnumHandling = EnumHandling.String;

				settings.PostProcess = document =>
				{
					document.Info.Title = "MicroFlow";
					document.Info.Version = "0.1.0";
					document.Info.Description = "See the project's repo on GitHub. Click the link below.";
					document.Info.Contact = new NSwag.SwaggerContact
					{
						Name = "Miguel Veloso",
						Url = "https://github.com/mvelosop/MicroFlow"
					};
				};
			});

			app.UseMvc();

			_appStartup.SetupDatabase(appServices);
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc()
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
				.AddJsonOptions(options =>
					options.SerializerSettings.Converters.Add(new StringEnumConverter()));

			services.AddSwagger();

			var appStartup = new Setup.Startup(Configuration);

			appStartup.ConfigureServices(services);
		}
	}
}