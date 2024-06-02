using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolManagementSystem.Domain.UnitOfWork;
using SchoolManagementSystem.Infrastructure.Authorization;
using SchoolManagementSystem.Infrastructure.DBContext;
using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Services;
using SchoolManagementSystem.StartUp.JWT;
using SchoolManagementSystem.StartUp.Middlewares;
using SchoolManagementSystem.StartUp.Swagger;
using SchoolManagementSystem.UnitOfWork;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("SchoolManagementSystem.Infrastructure")));

builder.Services.ConfigureSwaggerServices();
builder.Services.ConfigureJwtServices(builder.Configuration);

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configure interfaces and services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtAuthorization, JwtAuthorization>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.ConfigureSwaggerApp();
}

app.UseMiddleware<JwtMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();