using Domain.BaseEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Filters;
public class ResultWrapperlAttribute : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception != null)
        {
            return;
        }

        object result;
        if (context.Result == null || context.Result is EmptyResult)
        {
            result = new BaseResult();
        }
        else
        {
            result = new BaseResult(((ObjectResult)context.Result).Value);
        }
        
        context.Result = new ObjectResult(result);
    }

}