using MicroFlow.lib;

namespace MicroFlow.Domain.Commands
{
	public class ModifyBudgetItemTypeOrderCommand : IChangeCommand<int>
	{
		public ModifyBudgetItemTypeOrderCommand(
			int id,
			byte[] concurrencyToken,
			int order)
		{
			Id = id;
			ConcurrencyToken = concurrencyToken ?? throw new System.ArgumentNullException(nameof(concurrencyToken));
			Order = order;
		}

		public byte[] ConcurrencyToken { get; }

		public int Id { get; }

		public int Order { get; }
	}
}