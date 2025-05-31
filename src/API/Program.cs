using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(Application.AssemblyReference.Assembly);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
