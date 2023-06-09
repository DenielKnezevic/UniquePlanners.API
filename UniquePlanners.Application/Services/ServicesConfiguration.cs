﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Application.Services.PlannerCoversService;
using UniquePlanners.Application.Services.PlannerService;
using UniquePlanners.Application.Services.TokenService;
using UniquePlanners.Application.Services.UserService;

namespace UniquePlanners.Application.Services
{
    public static class ServicesDependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService.UserService>();
            services.AddTransient<IPlannerService, PlannerService.PlannerService>();
            services.AddTransient<IPlannerCoversService,  PlannerCoversService.PlannerCoversService>();
            services.AddTransient<ITokenService, TokenService.TokenService>();

            return services;
        }
    }
}
