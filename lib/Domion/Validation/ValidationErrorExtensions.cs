using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domion.Validation
{
	public static class ValidationErrorExtensions
	{
		public static IRuleBuilderOptions<T, TProperty>WithErrorMessage<T, TProperty>(
			this IRuleBuilderOptions<T, TProperty> rule,
			ErrorMessage error)
		{
			return rule.WithMessage(error.Message).WithErrorCode(error.Code);
		}
	}
}
