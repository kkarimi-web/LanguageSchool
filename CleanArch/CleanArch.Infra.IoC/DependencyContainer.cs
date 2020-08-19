
using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Application.Validations;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Repository;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application layer
            services.AddScoped<ICourseService, CourseService>();        

            //Infra.Data Layer
            services.AddScoped<ICourseRepository, CourseRepository>();

            //Domain layer
            services.AddSingleton<IValidator<Course>, CourseValidation>();
        }
    }
}
