using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Middleware
{
    public class UnwrapExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public UnwrapExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

       public async Task InvokeAsync(HttpContext context)
        {
            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }
}
