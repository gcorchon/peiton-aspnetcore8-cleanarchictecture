using Peiton.Infrastructure;
using Peiton.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Peiton.Configuration;
using Microsoft.AspNetCore.Authorization;
using Peiton.Api.Authorization;
using Peiton.Api;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration!;

builder.Services.AddProblemDetails()
                .AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddAuthorization()
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
            ValidAudience = builder.Configuration["JwtConfig:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:Secret"]!))
        };
    });

builder.Services.Configure<JwtConfig>(configuration.GetSection("JwtConfig"));
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient(s => s.GetService<IHttpContextAccessor>()!.HttpContext!.User); //<-- Para poder usar ClaimsPrincipal dentro de mis servicios.

// Add services to the container.
builder.Services.AddInfrastructure(configuration);
builder.Services.AddCore();

builder.Services.AddSingleton<IAuthorizationPolicyProvider, PeitonPermissionPolicyProvider>();
builder.Services.AddSingleton<IAuthorizationHandler, PeitonPermissionAuthorizationHandler>();

builder.Services.AddControllersWithViews(/*options =>
{
    options.Filters.Add(typeof(EntityNotFoundFilter), -3000);
    options.ModelBinderProviders.Insert(0, new EntityModelBinderProvider());
}*/).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.DictionaryKeyPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseStatusCodePages();
app.UseExceptionHandler();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
*/

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
