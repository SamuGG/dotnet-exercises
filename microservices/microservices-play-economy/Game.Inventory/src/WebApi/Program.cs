using System.Reflection;
using Game.Common.WebApi.Settings;
using Game.Inventory.Application.DependencyInjection;
using Game.Inventory.Infrastructure.DependencyInjection;
using Game.Inventory.WebApi.Filters;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? Environment.CurrentDirectory;
builder.Configuration.AddJsonFile(Path.Combine(assemblyPath, "httpCodeDescription.json"), optional: true);

builder.Services.AddControllers(options =>
{
    var settingsSection = builder.Configuration.GetRequiredSection(nameof(HttpCodeDescription));
    options.Filters.Add(new ApiExceptionFilter(settingsSection.Get<HttpCodeDescription>()));
    options.SuppressAsyncSuffixInActionNames = false;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "Inventory Service",
        Version = "v1",
        Description = "Web API for the inventory service"
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory v1"));
    
    app.UseCors(corsBuilder => 
        corsBuilder.WithOrigins(app.Configuration["AllowedOrigin"])
        .AllowAnyHeader()
        .AllowAnyMethod());
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();