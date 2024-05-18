using MTJM.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.AddApiConfiguration();
builder.AddSwaggerConfiguration();

var app = builder.Build();

app.UseSwaggerConfiguration();
app.UseApiConfiguration();

app.Run();
