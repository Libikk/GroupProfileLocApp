// <copyright file="QLUserContext.cs" company="Victor Saly">
// Copyright (c) Victor Saly. All rights reserved.
// </copyright>
// <auto-generated />
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProfileLocation.WebAPI.Models
{
    public class QLUserContext : Dictionary<string, object>
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public QLUserContext(HttpContext httpContext)
        {
            ServiceProvider = httpContext.RequestServices;
        }
    }
}
