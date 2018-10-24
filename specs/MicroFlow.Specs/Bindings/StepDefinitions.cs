using FluentAssertions;
using MicroFlow.Application.Services;
using MicroFlow.Domain.Model;
using MicroFlow.Specs.TestHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

		[When(@"I try to delete these budget item types after they've been updated I should get a concurrency exception:")]
		public async Task WhenITryToDeleteTheseBudgetItemTypesAfterTheyVeBeenUpdatedIShouldGetAConcurrencyException(Table table)
		{
			var items = table.CreateSet<BudgetItemTypeTestData>();

			var stallEntities = await DoGenericUpdatesAsync(items);

			// Failling delete
			using (var scope = CreateScope())
			{
				var services = scope.ServiceProvider.GetService<IBudgetItemTypeServices>();

				foreach (var item in stallEntities)
				{
					var entity = await services.FindByIdAsync(item.Id);

					entity.Should().NotBeNull();

					entity.CopyValuesFrom(item);
					entity.RowVersion = item.RowVersion;

					Func<Task> action = async () => await services.RemoveAsync(entity);

					action.Should().Throw<DbUpdateConcurrencyException>();
				}
			}
		}

		[When(@"I try to update these budget item types after they've been updated I should get a concurrency exception:")]
		public async Task WhenITryToUpdateTheseBudgetItemTypesAfterTheyVeBeenUpdatedIShouldGetAConcurrencyException(Table table)
		{
			var items = table.CreateSet<BudgetItemTypeTestData>();

			var stallEntities = await DoGenericUpdatesAsync(items);

			// Failling updates
			using (var scope = CreateScope())
			{
				var services = scope.ServiceProvider.GetService<IBudgetItemTypeServices>();

				foreach (var item in stallEntities)
				{
					var entity = await services.FindByIdAsync(item.Id);

					entity.Should().NotBeNull();

					entity.CopyValuesFrom(item);
					entity.RowVersion = item.RowVersion;

					Func<Task> action = async () => await services.UpdateAsync(entity);

					action.Should().Throw<DbUpdateConcurrencyException>();
				}
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

				entity.CopyValuesFrom(item);

				var result = await services.UpdateAsync(entity);

				result.IsValid.Should().BeFalse();

				var expectedErrors = item.ValidationErrors.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

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

				entity.CopyValuesFrom(item);

				var result = await services.UpdateAsync(entity);

				result.ValidationResult.Errors.Select(e => e.ErrorMessage).Should().BeEmpty();
			}
		}

		private IServiceScope CreateScope()
		{
			return _scenarioContext.Get<IServiceScope>(Hooks.ScopeKey)?.ServiceProvider.CreateScope();
		}

		private async Task<List<BudgetItemType>> DoGenericUpdatesAsync(IEnumerable<BudgetItemTypeTestData> items)
		{
			// Successful updates
			var stallEntities = new List<BudgetItemType>();

			using (var scope = CreateScope())
			{
				var services = scope.ServiceProvider.GetService<IBudgetItemTypeServices>();

				foreach (var item in items)
				{
					var entity = await services.FindByNameAsync(item.FindByName);

					entity.Should().NotBeNull();

					// Serialize and deserialize to easily clone object
					var stallEntity = JsonConvert.DeserializeObject<BudgetItemType>(JsonConvert.SerializeObject(entity));

					stallEntity.CopyValuesFrom(item);

					stallEntities.Add(stallEntity);

					entity.Notes = "Successful update";

					var result = await services.UpdateAsync(entity);

					result.IsValid.Should().BeTrue();
				}
			}

			return stallEntities;
		}

		private T GetService<T>() where T : class
		{
			return _scenarioContext.Get<IServiceScope>(Hooks.ScopeKey)?.ServiceProvider.GetService<T>();
		}
	}
}