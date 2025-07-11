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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//converter enums
builder.Services
    .AddControllers()
    .AddJsonOptions(opts =>
    {
        opts.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter());
    });

//conexao com a bd
var connectionString = builder.Configuration.GetConnectionString("ClinicaXPTOConnection");
builder.Services.AddDbContext<ClinicaContext>(options =>
    options.UseSqlServer(connectionString, sqplOptions =>
        sqplOptions.MigrationsAssembly(typeof(ClinicaContext).Assembly.FullName)));


//  AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

//  Repositórios
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAnonymousRequestRepository, AnonymousRequestRepository>();
builder.Services.AddScoped<IActTypeRepository, ActTypeRepository>();
builder.Services.AddScoped<IProfessionalRepository, ProfessionalRepository>();
builder.Services.AddScoped<IAppointmentRequestRepository, AppointmentRequestRepository>();
builder.Services.AddScoped<IAppointmentRequestItemRepository, AppointmentRequestItemRepository>();

//  Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAnonymousRequestService, AnonymousRequestService>();
builder.Services.AddScoped<IActTypeService, ActTypeService>();
builder.Services.AddScoped<IProfessionalService, ProfessionalService>();
builder.Services.AddScoped<IAppointmentRequestService, AppointmentRequestService>();
builder.Services.AddScoped<IAppointmentRequestItemService, AppointmentRequestItemService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();