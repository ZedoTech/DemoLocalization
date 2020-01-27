﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DemoLocalization.Infrastructures
{
    public class RouteValueRequestCultureProvider : IRequestCultureProvider
    {
        private readonly List<CultureInfo> _cultures;

        public RouteValueRequestCultureProvider(List<CultureInfo> cultures)
        {
            _cultures = cultures;
        }

        /// <summary>
        /// get {culture} route value from path string, 
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns>ProviderCultureResult depends on path {culture} route parameter, or default culture</returns>
        public Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            var defaultCulture = "zh-TW";

            var path = httpContext.Request.Path;

            if (string.IsNullOrWhiteSpace(path))
            {
                return Task.FromResult(new ProviderCultureResult(defaultCulture));
            }

            var routeValues = httpContext.Request.Path.Value.Split('/');
            if (routeValues.Count() <= 1)
            {
                return Task.FromResult(new ProviderCultureResult(defaultCulture));
            }

            if (!_cultures.Any(x => x.Name.ToLower() == routeValues[1].ToLower()))
            {
                return Task.FromResult(new ProviderCultureResult(defaultCulture));
            }

            return Task.FromResult(new ProviderCultureResult(routeValues[1]));
        }
    }
}
