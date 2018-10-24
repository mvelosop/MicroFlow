namespace MicroFlow.lib
{
	public interface IChangeCommand<T>
	{
		byte[] RowVersion { get; }

		T Id { get; }
	}
}