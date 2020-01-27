using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DemoLocalization.Middlewares
{
    public class CultureMiddleware
    {
        //private readonly RequestDelegate _next;
        //private readonly IApplicationBuilder _app;
        //public CultureMiddleware(RequestDelegate next, IApplicationBuilder app)
        //{
        //    _next = next;
        //    _app = app;
        //}

        public static readonly List<CultureInfo> _supportedCultures = new List<CultureInfo>
        {
            new CultureInfo("en-US"),
            new CultureInfo("zh-TW"),
            new CultureInfo("zh-CN"),
        };

        public static readonly RequestLocalizationOptions _localizationOptions = new RequestLocalizationOptions()
        {
            DefaultRequestCulture = new RequestCulture(_supportedCultures.First()),
            SupportedCultures = _supportedCultures,
            SupportedUICultures = _supportedCultures,
            RequestCultureProviders = new[]
            {
                new RouteDataRequestCultureProvider() { Options = _localizationOptions }
            }
        };

        public void Configure(IApplicationBuilder app)
        {
            app.UseRequestLocalization(_localizationOptions);
        }

        //public async Task InvokeAsync(HttpContext context)
        //{
        //    _app.UseRequestLocalization(_localizationOptions);
        //    // Call the next delegate/middleware in the pipeline
        //    await _next(context);
        //}
    }
}
