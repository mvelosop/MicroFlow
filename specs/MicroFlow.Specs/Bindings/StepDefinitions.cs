using FluentAssertions;
using MicroFlow.Domain.Model;
using MicroFlow.Domain.Services;
using MicroFlow.Specs.TestHelpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace MicroFlow.Specs.Bindings
{
	[Binding]
	public sealed class StepDefinitions
	{
		// For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

		private readonly ScenarioContext _scenarioContext;

		public StepDefinitions(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
		}

		[Then(@"I should get these budget item types when I query:")]
		public async Task ThenIGetTheseBudgetItemTypesWhenIQuery(Table table)
		{
			var services = GetService<IBudgetItemTypeServices>();

			var items = await services.GetListAsync();

			table.CompareToSet(items);
		}

		[When(@"I add the following budget item types:")]
		[Given(@"I have the following budget item types:")]
		public async Task WhenIAddTheFollowingBudgetItemTypes(Table table)
		{
			var items = table.CreateSet<BudgetItemType>();

			var services = GetService<IBudgetItemTypeServices>();

			foreach (var item in items)
			{
				var result = await services.AddAsync(item);

				result.Succeeded.Should().BeTrue();
			}
		}


		[When(@"I modify the following budget item types:")]
		public async Task WhenIModifyTheFollowingBudgetItemTypes(Table table)
		{
			var items = table.CreateSet<BudgetItemTypeTestData>();

			var services = GetService<IBudgetItemTypeServices>();

			foreach (var item in items)
			{
				var entity = await services.FindByNameAsync(item.FindByName);

				entity.Should().NotBeNull();

				entity.Name = item.Name;
				entity.Order = item.Order;
				entity.BudgetClass = item.BudgetClass;

				var result = await services.ModifyAsync(entity);

				result.Succeeded.Should().BeTrue();
			}
		}


		private T GetService<T>() where T : class
		{
			return _scenarioContext.Get<IServiceScope>(Hooks.ScopeKey)?.ServiceProvider.GetService<T>();
		}

	}
}