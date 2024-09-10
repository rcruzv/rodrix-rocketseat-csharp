using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionBase;
using CashFlow.Exception;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is CashFlowException)
        {
            Handle(context);
        }
        else
        {
            ThrowUnknown(context);
        }
    }

    private void Handle(ExceptionContext context)
    {
        if (context.Exception is ErrorOnValidationException exception)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(
                new ResponseError(
                    exception.Errors
                )
            );
        }
        else
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(
                new ResponseError(
                    context.Exception.Message
                )
            );
        }
    }

    private void ThrowUnknown(ExceptionContext context)
    {
        var response = new ResponseError(ResourceErrorMessage.UNKNOWN_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(response);
    }
}
