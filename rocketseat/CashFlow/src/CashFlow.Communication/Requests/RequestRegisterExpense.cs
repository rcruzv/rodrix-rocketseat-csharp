using CashFlow.Communication.Enums;

namespace CashFlow.Communication.Requests;
public class RequestRegisterExpense
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? ExpenseDate { get; set; }
    public decimal? Amount { get; set; }
    public PaymentType? PaymentType { get; set; }
}
