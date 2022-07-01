using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace tsogosun.com.MSProfileAdmin.App_Start
{
    public class LoggingActionFilter : IActionFilter
    {
        ILogger _logger;
        public LoggingActionFilter(ILoggerFactory loggerFactory)
        {

            _logger = loggerFactory.CreateLogger<LoggingActionFilter>();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

            // do something before the action executes
            _logger.LogInformation($"User SessionId {context.HttpContext.Request.Headers["userSessionId"]} Action {context.ActionDescriptor.DisplayName}");

            var actionParameters = context.ActionArguments;
            Dictionary<string, object> model = (Dictionary<string, object>)actionParameters;
            var serialRequestParameter = JsonConvert.SerializeObject(model);

            _logger.LogInformation($"Request Parameter {serialRequestParameter} ");

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // do something after the action executes            


            if (context?.Exception?.Message != null)
            {
                _logger.LogInformation($"Exception : {context?.Exception?.Message}");
            }

            _logger.LogInformation($"Response HTTP Status {context.HttpContext.Response.StatusCode}");

        }
    }
}