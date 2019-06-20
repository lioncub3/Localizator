using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace BestSite.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyAccessMiddleware
    {
        private readonly RequestDelegate _next;

        public MyAccessMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string token = httpContext.Request.Query["token"];

            if (token == "abc")
                await _next(httpContext);
            else
                await httpContext.Response.WriteAsync("Access denied");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    //public static class MyAccessMiddlewareExtensions
    //{
    //    public static IApplicationBuilder UseMyAccessMiddleware(this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<MyAccessMiddleware>();
    //    }
    //}
}
