using Domion.Base;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Domion.Mvc.Validation
{
	public static class ValidationResultExtensions
	{
		public static ValidationProblemDetails AsValidationProblemDetails(
			this ValidationResult validationResult,
			int status,
			string title,
			string detail)
		{
			if (validationResult.IsValid) throw new InvalidOperationException($"{nameof(validationResult)} must not be valid!");

			var problemDetail = new ValidationProblemDetails
			{
				Status = status,
				Title = title,
				Detail = detail
			};

			foreach (var errorGroup in validationResult.Errors.GroupBy(e => e.PropertyName))
			{
				problemDetail.Errors.Add(errorGroup.Key, errorGroup.Select(g => g.ErrorMessage).ToArray());
			}

			return problemDetail;
		}

	}
}