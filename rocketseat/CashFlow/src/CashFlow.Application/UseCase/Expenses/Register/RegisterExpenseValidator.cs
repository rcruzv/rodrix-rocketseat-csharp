using CashFlow.Communication.Requests;
using CashFlow.Exception;
using FluentValidation;

namespace CashFlow.Application.UseCase.Expenses.Register;
public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpense>
{
    public RegisterExpenseValidator()
    {
        RuleFor(expense => expense.Title)
            .NotEmpty()
            .WithMessage(ResourceErrorMessage.TITLE_REQUIRED);

        RuleFor(expense => expense.Amount)
            .GreaterThan(0)
            .WithMessage(ResourceErrorMessage.AMOUNT_REQUIRED);

        RuleFor(expense => expense.ExpenseDate)
            .LessThan(DateTime.UtcNow)
            .WithMessage(ResourceErrorMessage.EXPENSE_DATE_INVALID);

        RuleFor(expense => expense.PaymentType)
            .IsInEnum()
            .WithMessage(ResourceErrorMessage.PAYMENT_TYPE_INVALID);
    }
}
