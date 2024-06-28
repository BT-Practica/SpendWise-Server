using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using SpendWise_Server.Business;
using SpendWise_Server.Business.Interfaces;
using SpendWise_Server.Business.Services;
using SpendWise_Server.Repos.Interfaces;
using SpendWise_Server.Repos.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Creting the logger
Log.Logger = new LoggerConfiguration()
                            .WriteTo.File(new JsonFormatter(),
                                          "important.json",
                                          restrictedToMinimumLevel: LogEventLevel.Warning)
                            .WriteTo.File("all-.logs",
                                          rollingInterval: RollingInterval.Day)
                            //.WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                            .MinimumLevel.Debug()
                            .CreateLogger();


builder.Services.AddAuthentication(option => {
        option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(JwtOptions => {
        var key = builder.Configuration["Jwt:Key"];
        var keyBytes = Encoding.ASCII.GetBytes(key);
        JwtOptions.SaveToken = true;
        JwtOptions.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
            ValidateLifetime = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"]
        };

    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

BusinessRegistrations.RegisterDependecies(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
