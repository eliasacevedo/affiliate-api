using Domain.BaseEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> logger;
        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            this.logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            logger.LogError(context.Exception.Message, context.Exception);
            context.ExceptionHandled = true;

            object result = new BaseResult(context.Exception);
            context.Result = new ObjectResult(result);
        }
    }
}
