using FluentAssertions;
using MicroFlow.Application.Services;
using MicroFlow.Domain.Model;
using MicroFlow.Specs.TestHelpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
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
		public async Task ThenIShouldGetTheseBudgetItemTypesWhenIQuery(Table table)
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

				result.IsValid.Should().BeTrue();
			}
		}

		[When(@"I remove the following budget item types:")]
		public async Task WhenIRemoveTheFollowingBudgetItemTypes(Table table)
		{
			var items = table.CreateSet<BudgetItemTypeTestData>();

			var services = GetService<IBudgetItemTypeServices>();

			foreach (var item in items)
			{
				var entity = await services.FindByNameAsync(item.FindByName);

				entity.Should().NotBeNull();

				var result = await services.RemoveAsync(entity);

				result.IsValid.Should().BeTrue();
			}
		}

		[When(@"I try to add these budget item types I should get validation errors:")]
		public async Task WhenITryToAddTheseBudgetItemTypesIShouldGetValidationErrors(Table table)
		{
			var items = table.CreateSet<BudgetItemTypeTestData>();

			var services = GetService<IBudgetItemTypeServices>();

			foreach (var item in items)
			{
				var result = await services.AddAsync(item);

				var expectedErrors = item.ValidationErrors.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

				result.IsValid.Should().BeFalse();
				result.ValidationResult.Errors.Select(e => e.ErrorCode).Should().BeEquivalentTo(expectedErrors);
			}
		}

		[When(@"I try to update these budget item types I should get validation errors:")]
		public async Task WhenITryToUpdateTheseBudgetItemTypesIShouldGetValidationErrors(Table table)
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

				var result = await services.UpdateAsync(entity);

				var expectedErrors = item.ValidationErrors.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

				result.IsValid.Should().BeFalse();
				result.ValidationResult.Errors.Select(e => e.ErrorCode).Should().BeEquivalentTo(expectedErrors);
			}
		}

		[When(@"I update the following budget item types:")]
		public async Task WhenIUpdateTheFollowingBudgetItemTypes(Table table)
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

				var result = await services.UpdateAsync(entity);

				result.IsValid.Should().BeTrue();
			}
		}

		private T GetService<T>() where T : class
		{
			return _scenarioContext.Get<IServiceScope>(Hooks.ScopeKey)?.ServiceProvider.GetService<T>();
		}
	}
}