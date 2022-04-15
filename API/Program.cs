using API.Extensions;
using API.Mapper;
using AutoMapper.Extensions.ExpressionMapping;
using Business.Dtos;
using Business.Services;
using Business.Services.Interfaces;
using Business.Validators.User;
using DataAccess;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserDtoValidator>());

var jwtSettings = builder.Configuration.GetSection("JWT").Get<JWTSettingsDto>();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    var Key = Encoding.UTF8.GetBytes(jwtSettings.Key);
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Key)
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin",
         policy => policy.RequireRole("Admin"));
    options.AddPolicy("User",
        policy => policy.RequireRole("User"));
});

builder.Services.AddSingleton(new JWTSettingsDto()
{
    Key = jwtSettings.Key,
    Issuer = jwtSettings.Issuer,
    Audience = jwtSettings.Audience,
    Expiration = jwtSettings.Expiration
});

builder.Services.AddDbContext<HowToChessDbContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(mc =>
{
    mc.AddExpressionMapping();
    mc.AddProfile(new MapperProfile());
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPositionRepository, PositionRepository>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStockfishService, StockfishService>();
builder.Services.AddScoped<IPositionService, PositionService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

await app.UpdateDatabase();

app.Run();
