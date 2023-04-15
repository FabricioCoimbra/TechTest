using TechTest.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCustomSwagger()
    .AddHypnoboxRequester(builder.Configuration)
    .AddLog()
    .AddMemoryCache()
    .ConfigureServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpLogging();
app.MapControllers();

app.Run();
