using MicroFlow.lib;

namespace MicroFlow.Domain.Commands
{
	public class RemoveBudgetItemTypeCommand : IChangeCommand<int>
	{
		public RemoveBudgetItemTypeCommand(
			int id,
			byte[] concurrencyToken)
		{
			Id = id;
			ConcurrencyToken = concurrencyToken ?? throw new System.ArgumentNullException(nameof(concurrencyToken));
		}

		public byte[] ConcurrencyToken { get; }

		public int Id { get; }
	}
}