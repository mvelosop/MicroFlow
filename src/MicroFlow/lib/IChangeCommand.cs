namespace MicroFlow.lib
{
	public interface IChangeCommand<T>
	{
		byte[] ConcurrencyToken { get; }

		T Id { get; }
	}
}