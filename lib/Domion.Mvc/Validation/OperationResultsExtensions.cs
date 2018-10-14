using Domion.Base;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Domion.Mvc.Validation
{
	public static class OperationResultsExtensions
	{
		public static ValidationProblemDetails AsValidationProblemDetails(
			this OperationResult operationResult,
			int status,
			string title,
			string detail)
		{
			if (operationResult.IsValid) return default(ValidationProblemDetails);

			var problemDetail = new ValidationProblemDetails
			{
				Status = status,
				Title = title,
				Detail = detail
			};

			foreach (var errorGroup in operationResult.ValidationResult.Errors.GroupBy(e => e.PropertyName))
			{
				problemDetail.Errors.Add(errorGroup.Key, errorGroup.Select(g => g.ErrorMessage).ToArray());
			}

			return problemDetail;
		}
	}
}