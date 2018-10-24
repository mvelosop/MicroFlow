using MicroFlow.lib;

namespace MicroFlow.UnitTests.TestHelpers
{
	public class TestChangeCommand : IChangeCommand<int>
	{
		public byte[] RowVersion { get; set; }

		public int Id { get; set; }
	}
}