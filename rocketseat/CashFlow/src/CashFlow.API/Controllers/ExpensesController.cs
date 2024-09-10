﻿using CashFlow.Application.UseCase.Expenses.Register;
using CashFlow.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterExpense request)
    {
        var response = new RegisterExpenseUseCase().Execute(request);
        return Created(string.Empty, response);
    }
}
