using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using ToDo.List.CrossCutting.Swagger;
using ToDo.List.Domain.DTOs;
using ToDo.List.Domain;
using ToDo.List.Domain.Interfaces;
using ToDo.List.Domain.Services;
using ToDo.List.Infra.Data.Data;
using ToDo.List.Infra.Data.Repositories;

namespace ToDo.List.CrossCutting;

public static class DependencyInjection
{
    public static void AddDependencyInjection(this WebApplicationBuilder builder)
    {

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
            .AllowAnyHeader());
        });

        builder.Services.AddDbContext<ToDoListDbContext>(opt =>
        {
            opt.UseSqlServer(builder.Configuration["DbConnection"]);
        });


        builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IAccountRepository, AccountRepository>();
        builder.Services.AddScoped<IAccountService, AccountService>();


        builder.AddSwaggerAuthorizationJWTDependencyInjection();
        builder.AddAuthenticationJwtExtension();
        builder.Services.AddScoped<IValidator<AccountRequestDTO>, AccountRequestValidator>();

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddFluentValidationAutoValidation();
    }
}