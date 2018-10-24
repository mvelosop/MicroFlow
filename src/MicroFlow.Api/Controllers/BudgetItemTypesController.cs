using Domion.Base;
using Domion.Mvc.Validation;
using MicroFlow.Application.Services;
using MicroFlow.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroFlow.Api.Controllers
{
	[Route("api/v1/[controller]")]
	public class BudgetItemTypesController : Controller
	{
		private const string RowVersionIsRequired = "The rowVersion is required!";
		private const string InvalidRequestTitle = "Invalid Request!";
		private const string ModelIdMustBeCeroMessage = "The model id must be cero!";
		private const string ModelIsRequiredMessage = "The model is required!";
		private const string RequestIdAndModelIdDontMatchMessage = "The request id and the model id don't match!";
		private const string RequestIdMustNotBeCeroMessage = "The request id must not be cero!";
		private const string ValidationErrorsDetailMessage = "The operation can't proceed because of one or more validation errors.";
		private const string ValidationErrorsTitle = "Validation Errors Occurred!";

		private readonly IBudgetItemTypeServices _services;

		public BudgetItemTypesController(IBudgetItemTypeServices services)
		{
			_services = services;
		}

		// DELETE api/<controller>/5
		[HttpDelete("{id}")]
		[SwaggerResponse(200, typeof(void))]
		[SwaggerResponse(400, typeof(ProblemDetails), Description = "Bad request")]
		[SwaggerResponse(404, typeof(void), Description = "Not found")]
		[SwaggerResponse(422, typeof(ValidationProblemDetails), Description = "Validation errors")]
		public async Task<ActionResult> Delete(int id, [FromBody]byte[] rowVersion)
		{
			if (id == 0) return BadRequestProblem(RequestIdMustNotBeCeroMessage);
			if (rowVersion is null) return BadRequestProblem(RowVersionIsRequired);

			var entity = await _services.FindByIdAsync(id);

			if (entity is null) return NotFound();

			var result = await _services.RemoveAsync(entity);

			if (!result.IsValid) return ValidationErrorsProblem(result);

			return Ok();
		}

		// GET api/<controller>/5
		[HttpGet("{id}")]
		[SwaggerResponse(200, typeof(BudgetItemType))]
		[SwaggerResponse(400, typeof(ProblemDetails), Description = "Bad request")]
		[SwaggerResponse(404, typeof(void), Description = "Not found")]
		public async Task<ActionResult<BudgetItemType>> Get(int id)
		{
			if (id == 0) return BadRequestProblem(RequestIdMustNotBeCeroMessage);

			var entity = await _services.FindByIdAsync(id);

			if (entity is null) return NotFound();

			return Ok(entity);
		}

		// GET: api/<controller>
		[HttpGet]
		[SwaggerResponse(200, typeof(List<BudgetItemType>))]
		[SwaggerResponse(400, typeof(ProblemDetails), Description = "Bad request")]
		public async Task<ActionResult<List<BudgetItemType>>> GetItems()
		{
			return Ok(await _services.GetListAsync());
		}

		// POST api/<controller>
		[HttpPost]
		[SwaggerResponse(200, typeof(BudgetItemType))]
		[SwaggerResponse(400, typeof(ProblemDetails), Description = "Bad request")]
		[SwaggerResponse(422, typeof(ValidationProblemDetails), Description = "Validation errors")]
		public async Task<ActionResult<BudgetItemType>> Post([FromBody]BudgetItemType model)
		{
			if (model is null) return BadRequestProblem(ModelIsRequiredMessage);
			if (model.Id != 0) return BadRequestProblem(ModelIdMustBeCeroMessage);

			var result = await _services.AddAsync(model);

			if (!result.IsValid) return ValidationErrorsProblem(result);

			return Ok(model);
		}

		// PUT api/<controller>/5
		[HttpPut("{id}")]
		[SwaggerResponse(200, typeof(BudgetItemType))]
		[SwaggerResponse(400, typeof(ProblemDetails), Description = "Bad request")]
		[SwaggerResponse(404, typeof(void), Description = "Not found")]
		[SwaggerResponse(422, typeof(ValidationProblemDetails), Description = "Validation errors")]
		public async Task<ActionResult<BudgetItemType>> Put(int id, [FromBody]BudgetItemType model)
		{
			if (model is null) return BadRequestProblem(ModelIsRequiredMessage);
			if (id == 0) return BadRequestProblem(RequestIdMustNotBeCeroMessage);
			if (id != model.Id) return BadRequestProblem(RequestIdAndModelIdDontMatchMessage);

			var entity = await _services.FindByIdAsync(id);

			if (entity is null) return NotFound();

			UpdateEntity(model, entity);

			var result = await _services.UpdateAsync(entity);

			if (!result.IsValid) return ValidationErrorsProblem(result);

			return Ok(entity);
		}

		private BadRequestObjectResult BadRequestProblem(string detail)
		{
			return BadRequest(
				new ProblemDetails
				{
					Title = InvalidRequestTitle,
					Detail = detail,
					Status = StatusCodes.Status400BadRequest
				}
			);
		}

		private void UpdateEntity(BudgetItemType model, BudgetItemType entity)
		{
			entity.BudgetClass = model.BudgetClass;
			entity.RowVersion = model.RowVersion;
			entity.Name = model.Name;
			entity.Notes = model.Notes;
			entity.Order = model.Order;
		}

		private ActionResult ValidationErrorsProblem(OperationResult result)
		{
			return UnprocessableEntity(result.ValidationResult.AsValidationProblemDetails(422, ValidationErrorsTitle, ValidationErrorsDetailMessage));
		}
	}
}