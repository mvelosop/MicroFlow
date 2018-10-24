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
		public void ValidateRowVersion()
		{
			// Arrange -----------------
			var validator = new ChangeCommandValidator<int>();

			// Act ---------------------

			// Assert ------------------
			validator.ShouldNotHaveValidationErrorFor(c => c.RowVersion, new TestChangeCommand { Id = 1, RowVersion = new byte[] { 1, 2 } });

			validator.ShouldHaveValidationErrorFor(c => c.RowVersion, new TestChangeCommand { Id = 1 })
				.WithErrorMessage("'Row Version' should not be empty.");

			validator.ShouldHaveValidationErrorFor(c => c.RowVersion, new TestChangeCommand { Id = 1, RowVersion = new byte[] { } })
				.WithErrorMessage("'Row Version' should not be empty.");

		}

	}
}
