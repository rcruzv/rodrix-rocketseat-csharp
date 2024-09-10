using Bogus;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace CashFlow.Test.Utils.Requests;
public class RequestRegisterExpenseBuilder
{
    public static RequestRegisterExpense Build()
    {
        return new Faker<RequestRegisterExpense>()
            .RuleFor(r => r.Title, f => f.Commerce.Product())
            .RuleFor(r => r.Amount, f => f.Random.Decimal(0, 1000))
            .RuleFor(r => r.Description, f => f.Commerce.ProductDescription() )
            .RuleFor(r => r.ExpenseDate, f => f.Date.Past())
            .RuleFor(r => r.PaymentType, f => f.PickRandom<PaymentType>());
    }
}
