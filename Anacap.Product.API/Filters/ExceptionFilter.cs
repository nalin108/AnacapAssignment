using Anacap.Product.API.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anacap.Product.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        readonly IWebHostEnvironment _environment;

        public ExceptionFilter(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public void OnException(ExceptionContext context)
        {
            var error = new ApiError()
            {
                Message = context.Exception.Message
            };

            if (_environment.EnvironmentName.ToLower().Equals("development"))
                error.Details = context.Exception.StackTrace;

            //serialize to json
            context.Result = new ObjectResult(error)
            {
                StatusCode = 500
            };
        }
    }
}
