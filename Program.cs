using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pizza_API.Data;
using Pizza_API.Extensions;
using Pizza_API.Models;
using Pizza_API.Repositories;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.InjectDependencies();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
