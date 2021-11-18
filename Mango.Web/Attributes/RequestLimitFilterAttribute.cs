using System.Threading.Tasks;
using Mango.Extensions;
using Mango.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Mango.Attributes
{
    public class RequestLimitFilterAttribute : ActionFilterAttribute
    {
        private readonly IRequestLimitService _requestLimitService;
        
        public RequestLimitFilterAttribute(IRequestLimitService requestLimitService)
        {
            _requestLimitService = requestLimitService;
        }

        public override async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            var errorMessage = await _requestLimitService.GetErrorMessage(context.HttpContext.GetRequestIp());
            
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                context.Result = new ObjectResult(context.ModelState)
                {
                    Value = errorMessage,
                    StatusCode = StatusCodes.Status429TooManyRequests
                };
            }
            
            await base.OnActionExecutionAsync(context, next);
        }
    }
}