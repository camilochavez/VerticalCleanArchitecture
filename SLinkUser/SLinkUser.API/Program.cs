using Carter;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SLinkUser.API.DependencyInjection;
using SLinkUser.API.Extension;
using SLinkUser.API.Features.DeleteUser;
using SLinkUser.API.Features.UpdateUser;
using SLinkUser.API.Handler;
using SLinkUser.Infrastructure;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly).
                                    AddValidation<UpdateUserCommand, bool>().
                                    AddValidation<DeleteUserCommand, bool>()
);
builder.Services.AddDbContext<UserDbContext>(opt =>
              opt.UseInMemoryDatabase("SLinkUserDB"));
builder.Services.AddScoped<IValidator<UpdateUserCommand>, UpdateUserValidator>();
builder.Services.AddScoped<IValidator<DeleteUserCommand>, DeleteUserValidator>();
builder.Services.RegisterApiServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCarter();
builder.Services.AddHttpClient();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();
app.MapCarter();
app.Run();


