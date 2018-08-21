using FluentValidation.TestHelper;
using MicroFlow.Lib.Validators;
using MicroFlow.UnitTests.TestHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MicroFlow.UnitTests.Domain.Validators_Tests
{
	public class ChangeCommandValidator_Should
	{
		[Fact]
		public void ValidateId()
		{
			// Arrange -----------------
			var validator = new ChangeCommandValidator<int>();

			// Act ---------------------

			// Assert ------------------
			validator.ShouldNotHaveValidationErrorFor(c => c.Id, new TestChangeCommand { Id = 1 });

			validator.ShouldHaveValidationErrorFor(c => c.Id, new TestChangeCommand())
				.WithErrorMessage("'Id' should not be empty.");

		}

		[Fact]
		public void ValidateConcurrencyToken()
		{
			// Arrange -----------------
			var validator = new ChangeCommandValidator<int>();

			// Act ---------------------

			// Assert ------------------
			validator.ShouldNotHaveValidationErrorFor(c => c.ConcurrencyToken, new TestChangeCommand { Id = 1, ConcurrencyToken = new byte[] { 1, 2 } });

			validator.ShouldHaveValidationErrorFor(c => c.ConcurrencyToken, new TestChangeCommand { Id = 1 })
				.WithErrorMessage("'Concurrency Token' should not be empty.");

			validator.ShouldHaveValidationErrorFor(c => c.ConcurrencyToken, new TestChangeCommand { Id = 1, ConcurrencyToken = new byte[] { } })
				.WithErrorMessage("'Concurrency Token' should not be empty.");

		}

	}
}
