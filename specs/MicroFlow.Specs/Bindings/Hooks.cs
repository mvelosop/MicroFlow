using MicroFlow.Setup;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;

namespace MicroFlow.Specs.Bindings
{
	[Binding]
	public sealed class Hooks
	{
		private static TestHost testHost;

		private readonly ScenarioContext _scenarioContext;

		// For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

		public Hooks(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
		}

		public static string ScopeKey => "-Scope-";

		[BeforeTestRun]
		public static void BeforeTestRun()
		{
			testHost = new TestHost();

			testHost.Run();
		}

		[AfterStep]
		public void AfterStep()
		{
			if (_scenarioContext.TryGetValue(ScopeKey, out IServiceScope scope))
			{
				scope?.Dispose();

				_scenarioContext.Remove(ScopeKey);
			}
		}

		[BeforeStep]
		public void BeforeStep()
		{
			var scope = testHost.CreateScope();

			_scenarioContext.Set(scope, ScopeKey);
		}
	}
}