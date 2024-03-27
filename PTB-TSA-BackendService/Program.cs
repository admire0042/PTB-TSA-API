using ApplicationServices.DTOs;
using ApplicationServices.Interfaces;
using ApplicationServices.Services;
using ApplicationServices.Validations;
using Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence.DBContexts;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PremiumTrustBank TSA Api",
        Version = "v1"
    });
});
builder.Services.AddEndpointsApiExplorer();

#region Validators
builder.Services.AddTransient<IValidator<TSAReport>,TSAReportValidation>();
builder.Services.AddTransient<IValidator<NewTSAReportDto>, NewTSAReportDtoValidator>();
builder.Services.AddTransient<IValidator<ApproveTSAByAuthorizerDto>, ApproveTSAByAuthorizerDtoValidator>();
builder.Services.AddTransient<IValidator<ApproveBySupperAuthorizerDto>, ApproveTSABySuperAuthorizerDtoDtoValidator>();
builder.Services.AddTransient<IValidator<RejectTSAByAuthorizerDto>, RejectByAuthorizerDtoValidator>();
builder.Services.AddTransient<IValidator<RejectedBySupperAuthorizerDto>, RejectBySuperAuthorizerDtoValidator>();
#endregion

#region services
builder.Services.AddTransient<IInputterService, InputterService>();
builder.Services.AddTransient<IAuthorizerService, AuthorizerService>();
builder.Services.AddTransient<ISuperAuthorizerService, SuperAuthorizerService>();
builder.Services.AddTransient<ITSAReport, TSAReportService>();

#endregion

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.SetIsOriginAllowed(hostName => true)
                                                       .AllowAnyMethod()
                                                       .AllowAnyHeader()
                                                       .AllowCredentials()
    );
});
builder.Services.AddScoped<IAppDbContext, AppDbContext>();
var connectionString = builder.Configuration.GetConnectionString("DBConnection");
builder.Services.AddDbContext<AppDbContext>(options =>

    options.UseSqlServer(connectionString,
        b =>
        {
            b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
            b.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            b.CommandTimeout(3 * 60);
        })
         .EnableDetailedErrors());


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PremiumTrustBank TSA Api");
});

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
