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


var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PremiumTrustBank TSA Api");
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.SetIsOriginAllowed(hostName => true)
                                                       .AllowAnyMethod()
                                                       .AllowAnyHeader()
                                                       .AllowCredentials()
    );
});

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


app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
