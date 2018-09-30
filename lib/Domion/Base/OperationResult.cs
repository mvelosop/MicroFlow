using FluentValidation.Results;

namespace Domion.Base
{
	public class OperationResult
	{
		public OperationResult(
			ValidationResult validationResult)
		{
			ValidationResult = validationResult;
		}

		public bool Failed => !ValidationResult.IsValid;

		public bool Succeeded => ValidationResult.IsValid;

		public ValidationResult ValidationResult { get; }
	}

	public class OperationResult<TResult> : OperationResult
	{
		public OperationResult(
			ValidationResult validationResult,
			TResult value)
			: base(validationResult)
		{
			Value = value;
		}

		public TResult Value { get; }
	}
}