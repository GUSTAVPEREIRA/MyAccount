using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyAccount.Utils.Exceptions;

namespace MyAccount.Utils.Filters
{
    public class ApiExceptionsFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is ApiExceptions exception)
            {
                context.Result = new ObjectResult(exception.Value)
                {
                    StatusCode = (int?)exception.StatusCode,
                };
                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {            
        }
    }
}