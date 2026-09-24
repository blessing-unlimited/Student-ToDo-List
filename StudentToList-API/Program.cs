using StudentToList_API.Services;
using Microsoft.EntityFrameworkCore;
using StudentToList_API.Models;
using StudentToList_API.DTO;
using StudentToList_API.Controllers;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("ToDoListDb"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Students.AddRange(
        new Student { StudentId = Guid.NewGuid(), Name = "Blessing", Lastname = "Makhukhula", Email = "blessing@example.com" }
    );
    db.SaveChanges();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
