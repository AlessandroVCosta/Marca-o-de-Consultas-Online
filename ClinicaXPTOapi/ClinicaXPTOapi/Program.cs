using AutoMapper;
using ClinicaXPTO.DAL.Context;
using ClinicaXPTO.DAL.Repository;
using ClinicaXPTO.SHARED.IRepository;
using ClinicaXPTO.SHARED.IService;
using ClinicaXPTO.SERVICE.MappingProfiles;
using ClinicaXPTO.SERVICE.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using ClinicaXPTO.MODEL.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ========================================
// CONFIGURAÇÃO DE CORS
// ========================================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// ========================================
// Serviços da aplicação
// ========================================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<JwtService>();

builder.Services
    .AddControllers()
    .AddJsonOptions(opts =>
    {
        opts.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter());
    });

// Conexão com a BD
var connectionString = builder.Configuration.GetConnectionString("ClinicaXPTOConnection");
builder.Services.AddDbContext<ClinicaContext>(options =>
    options.UseSqlServer(connectionString, sqlOptions =>
        sqlOptions.MigrationsAssembly(typeof(ClinicaContext).Assembly.FullName)));

// AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

// Repositórios
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAnonymousRequestRepository, AnonymousRequestRepository>();
builder.Services.AddScoped<IActTypeRepository, ActTypeRepository>();
builder.Services.AddScoped<IProfessionalRepository, ProfessionalRepository>();
builder.Services.AddScoped<IAppointmentRequestRepository, AppointmentRequestRepository>();
builder.Services.AddScoped<IAppointmentRequestItemRepository, AppointmentRequestItemRepository>();

// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAnonymousRequestService, AnonymousRequestService>();
builder.Services.AddScoped<IActTypeService, ActTypeService>();
builder.Services.AddScoped<IProfessionalService, ProfessionalService>();
builder.Services.AddScoped<IAppointmentRequestService, AppointmentRequestService>();
builder.Services.AddScoped<IAppointmentRequestItemService, AppointmentRequestItemService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

// Autenticação JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

var app = builder.Build();

// ========================================
// MIDDLEWARE
// ========================================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use CORS antes da autenticação
app.UseCors("AllowAngularFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
