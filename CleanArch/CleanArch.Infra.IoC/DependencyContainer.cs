
using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Application.Validations;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Infrastructure;
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
            services.AddScoped<ICourseTypeService, CourseTypeService>();
            services.AddScoped<IFileRepositoryService, FileRepositoryService>();
            services.AddScoped<ICourseDocumentService, CourseDocumentServie>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IAttachmentTypeService, AttachmentTypeService>();

            //Infra.Data Layer
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseTypeRepository, CourseTypeRepository>();
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<ICourseDocumentRepository, CourseDocumentRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IAttachmentTypeRepository, AttachmentTypeRepository>();
            
            //Domain layer
            services.AddSingleton<IValidator<Course>, CourseValidation>();
            services.AddSingleton<IValidator<Person>, PersonValidation>();
        }
    }
}
