using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCase.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisterExpense Execute(RequestRegisterExpense request)
    {
        Validate(request);

        return new();
    }

    private void Validate(RequestRegisterExpense request)
    {
        var result = new RegisterExpenseValidator().Validate(request);
        if (!result.IsValid) {

            var exceptions = result.Errors.Select(s => s.ErrorMessage).ToList();
            
            throw new ErrorOnValidationException(exceptions);
        }
    }
}
