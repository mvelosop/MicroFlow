using System.IO;
using System.Runtime.CompilerServices;

namespace Domion.Validation
{
	public class ErrorMessage
	{
		public ErrorMessage(
			string message,
			[CallerFilePath] string errorClass = "",
			[CallerMemberName] string errorName = "")
		{
			Message = message;
			ErrorClass = errorClass;
			ErrorName = errorName;
		}

		public string Code => $"{Path.GetFileNameWithoutExtension(ErrorClass)}-{ErrorName}";

		public string ErrorClass { get; }

		public string ErrorName { get; }

		public string Message { get; }
	}
}