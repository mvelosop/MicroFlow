﻿using MicroFlow.Application.Services;
using MicroFlow.Domain.Repositories;
using MicroFlow.Domain.Services;
using MicroFlow.Domain.Validators;
using MicroFlow.Infrastructure.Data.Configuration;
using MicroFlow.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MicroFlow.Setup
{
	public class Startup
	{
		private readonly object _lockObject = new object();

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<BudgetDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddScoped<IBudgetItemTypeRepository, BudgetItemTypeRepository>();
			services.AddScoped<IBudgetItemTypeServices, BudgetItemTypeServices>();
			services.AddScoped<AddBudgetItemTypeValidator>();
		}

		public void SetupDatabase(IServiceProvider serviceProvider)
		{
			lock (_lockObject)
			{
				var dbContext = serviceProvider.GetService<BudgetDbContext>();

				dbContext.Database.Migrate();
			}
		}
	}
}