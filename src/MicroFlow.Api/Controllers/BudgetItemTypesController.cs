using FluentValidation.AspNetCore;
using MicroFlow.Application.Services;
using MicroFlow.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Domion.Mvc.Validation;
using static System.Net.WebRequestMethods;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroFlow.Api.Controllers
{
	[Route("api/v1/[controller]")]
	public class BudgetItemTypesController : Controller
	{
		private readonly IBudgetItemTypeServices _services;

		public BudgetItemTypesController(IBudgetItemTypeServices services)
		{
			_services = services;
		}

		// DELETE api/<controller>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id, [FromBody]byte[] concurrencyToken)
		{
			if (concurrencyToken is null) return BadRequest();
			if (id == 0) return BadRequest();

			var entity = await _services.FindByIdAsync(id);

			if (entity is null) return NotFound();

			await _services.RemoveAsync(entity);

			return Ok();
		}

		// GET api/<controller>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			if (id == 0) return BadRequest();

			var entity = await _services.FindByIdAsync(id);

			if (entity is null) return NotFound();

			return Ok(entity);
		}

		// GET: api/<controller>
		[HttpGet]
		public async Task<IActionResult> GetItems()
		{
			return Ok(await _services.GetListAsync());
		}

		// POST api/<controller>
		[HttpPost]
		public async Task<ActionResult<BudgetItemType>> Post([FromBody]BudgetItemType model)
		{
			if (model is null)
			{
				var error = new ProblemDetails();

				error.Detail = "BudgetItemType is required!";
				error.Status = StatusCodes.Status400BadRequest;

				return BadRequest(error);
			}

			if (model.Id != 0)
			{
				var error = new ProblemDetails();

				error.Title = "Invalid request";
				error.Detail = "id must be cero to POST!";
				error.Status = StatusCodes.Status400BadRequest;

				return BadRequest(error);
			}

			var result = await _services.AddAsync(model);

			if (!result.IsValid)
			{
				result.ValidationResult.AddToModelState(ModelState, null);

				var problem = new ValidationProblemDetails(ModelState);

				return UnprocessableEntity(result.AsValidationProblemDetails(422, "Validation Errors Occurred!",
					"The operation can't proceed because of one or more validation errors."));
			}

			return Ok(model);
		}

		// PUT api/<controller>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody]BudgetItemType model)
		{
			if (model is null) return BadRequest();
			if (id == 0) return BadRequest();
			if (id != model.Id) return BadRequest();

			var entity = await _services.FindByIdAsync(id);

			if (entity is null) return NotFound();

			UpdateEntity(model, entity);

			var result = await _services.UpdateAsync(entity);

			if (!result.IsValid) return UnprocessableEntity();

			return Ok(entity);
		}

		private void UpdateEntity(BudgetItemType model, BudgetItemType entity)
		{
			entity.BudgetClass = model.BudgetClass;
			entity.ConcurrencyToken = model.ConcurrencyToken;
			entity.Name = model.Name;
			entity.Notes = model.Notes;
			entity.Order = model.Order;
		}
	}
}