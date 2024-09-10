using CashFlow.Application.UseCase.Expenses.Register;
using CashFlow.Communication.Enums;
using CashFlow.Exception;
using CashFlow.Test.Utils.Requests;
using FluentAssertions;

namespace CashFlow.Test.Validators.Expenses.Register;
public class ResponseRegisterExpenseValidatorTest
{
    [Fact]
    public void Success()
    {
        //Arrange
        var validator   = new RegisterExpenseValidator();
        var request     = RequestRegisterExpenseBuilder.Build();

        //Act
        var result      = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("     ")]
    [InlineData(null)]
    public void Error_Title_Required(string? title)
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseBuilder.Build();
        request.Title = title;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle()
            .And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessage.TITLE_REQUIRED));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-2)]
    [InlineData(-7)]
    public void Error_Amount_Required(decimal value)
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseBuilder.Build();
        request.Amount = value;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle()
            .And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessage.AMOUNT_REQUIRED));
    }

    [Fact]
    public void Error_Expense_Date_Future()
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseBuilder.Build();
        request.ExpenseDate = DateTime.UtcNow.AddDays(1);

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle()
            .And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessage.EXPENSE_DATE_INVALID));
    }

    [Fact]
    public void Error_Payment_Type_Invalid()
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseBuilder.Build();
        request.PaymentType = (PaymentType)700;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle()
            .And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessage.PAYMENT_TYPE_INVALID));
    }
}
