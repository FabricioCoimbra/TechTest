using Microsoft.AspNetCore.HttpLogging;
using TechTest.service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITeamScoresService, TeamScoresService>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IHypnoBoxRequester, HypnoBoxRequester>();
builder.Services.AddLogging();
builder.Services.AddHttpLogging(options => options.LoggingFields = HttpLoggingFields.ResponseStatusCode | HttpLoggingFields.RequestPath);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpLogging();

app.UseAuthorization();

app.MapControllers();

app.Run();
