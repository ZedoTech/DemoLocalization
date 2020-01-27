using DemoLocalization.Infrastructures;
using DemoLocalization.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DemoLocalization.Extensions
{
    public static class LocalizationExtension
    {
        /// <summary>
        /// localize request according to {culture} route value.
        /// define supported cultures list, 
        /// define default culture for fallback,
        /// customize culture info e.g.: dat time format, digit shape,...
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureRequestLocalization(this IServiceCollection services)
        {
            //var cultures = new CultureInfo[]
            //{
            //    new CultureInfo("en-US"),
            //    new CultureInfo("zh-TW"),
            //    new CultureInfo("zh-CN"),
            //    //new CultureInfo("ar") {
                    
            //    //    /* change calendar to Grgorian */
            //    //    DateTimeFormat = { Calendar = new GregorianCalendar() },

            //    //    /* change digit shape */
            //    //    NumberFormat = { NativeDigits = "0 1 2 3 4 5 6 7 8 9".Split(" ") }
            //    //}
            //};

            services.Configure<RequestLocalizationOptions>(ops =>
            {
                ops.DefaultRequestCulture = new RequestCulture(CultureMiddleware._supportedCultures.FirstOrDefault());
                //ops.SupportedCultures = cultures.ToList();
                ops.SupportedCultures = CultureMiddleware._supportedCultures;
                //ops.SupportedUICultures = cultures.ToList();
                ops.SupportedUICultures = CultureMiddleware._supportedCultures;

                // add RouteValueRequestCultureProvider to the beginning of the providers list. 
                ops.RequestCultureProviders.Insert(0,
                    new RouteValueRequestCultureProvider(CultureMiddleware._supportedCultures));
            });
        }
    }
}
