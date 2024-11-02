using Microsoft.FeatureManagement;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFeatureManagement();

var app = builder.Build();

app.MapGet("/", () => Results.Text("Try browsing to \"/featureA\""));

app.MapGet("/featureA", async (IFeatureManager featureManager) =>
    await featureManager.IsEnabledAsync("FeatureA")
        ? Results.Text("Feature A is enabled")
        : Results.Problem(
            detail: "Feature A is disabled",
            instance: null,
            statusCode: (int)System.Net.HttpStatusCode.NotImplemented,
            title: "Feature Disabled"));

app.Run();