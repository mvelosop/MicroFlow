using MicroFlow.lib;

namespace MicroFlow.UnitTests.TestHelpers
{
	public class TestChangeCommand : IChangeCommand<int>
	{
		public byte[] ConcurrencyToken { get; set; }

		public int Id { get; set; }
	}
}