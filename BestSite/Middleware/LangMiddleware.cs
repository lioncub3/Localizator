using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace BestSite.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LangMiddleware
    {
        private readonly RequestDelegate _next;

        public LangMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            string lang = httpContext.Request.Query["lang"];

            if (!String.IsNullOrEmpty(lang))
                httpContext.Session.SetString("lang", lang);

            lang = httpContext.Session.GetString("lang") ?? "uk";

            try
            {
                CultureInfo.CurrentCulture = new CultureInfo(lang);
                CultureInfo.CurrentUICulture = new CultureInfo(lang);
            }
            catch (Exception) { }

            return _next(httpContext);
        }
    }
}
