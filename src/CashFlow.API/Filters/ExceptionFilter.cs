using CashFlow.Communication.Responses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.API;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is CashFlowException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknownError(context);
        }
    }

    private static void HandleProjectException(ExceptionContext context)
    {
        if (context.Exception is ErrorOnValidationException exception)
        {
            var errorResponse = new ResponseErrorJson(exception.Errors);
            
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(errorResponse);
        }
        else
        {
            var errorResponse = new ResponseErrorJson(context.Exception.Message);
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(errorResponse);
        }
    }
    
    private static void ThrowUnknownError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson(ResourceErrorMessages.UNKNOWN_ERROR);
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}