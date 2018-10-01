using FluentValidation.Results;

namespace Domion.Base
{
	public class OperationResult
	{
		public OperationResult()
			: this(new ValidationResult())
		{
		}

		public OperationResult(
			ValidationResult validationResult)
		{
			ValidationResult = validationResult;
		}

		public bool IsValid => ValidationResult.IsValid;

		public ValidationResult ValidationResult { get; }
	}

	public class OperationResult<TResult> : OperationResult
	{
		public OperationResult(
			ValidationResult validationResult)
			: this(validationResult, default(TResult))
		{
		}

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