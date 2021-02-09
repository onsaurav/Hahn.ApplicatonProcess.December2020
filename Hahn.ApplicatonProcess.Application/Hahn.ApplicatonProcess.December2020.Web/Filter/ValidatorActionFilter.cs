using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Hahn.ApplicatonProcess.December2020.Web.Filter
{
    public class ValidatorActionFilter : IActionFilter
    {
        ILogger<ValidatorActionFilter> _logger;
        public ValidatorActionFilter(ILogger<ValidatorActionFilter> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var url = filterContext.HttpContext.Request.Path.ToString();
            _logger.LogInformation(string.Format("New API Call : {0}", url));

            if (!filterContext.ModelState.IsValid)
            {
                filterContext.Result = new BadRequestObjectResult(filterContext.ModelState);
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
    }
}
