using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseStaticFiles();

app.MapControllers();

app.MapGet("/index.json", async context =>
{
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("Index.json");

    var webRoot = app.Environment.WebRootPath;
    var fileProvider = new PhysicalFileProvider(webRoot);

    var indexJson = fileProvider.GetFileInfo("index-nuget.json");

    context.Response.ContentType = "application/json";
    await context.Response.SendFileAsync(indexJson);
});

app.MapFallback(async context =>
{
    var response = new
    {
        context.Request.Path,
        context.Request.Method,
        context.Request.Query,
        context.Request.Headers,
        context.Request.Cookies,
        context.Request.Body,
    };

    var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("Fallback: {@Response}", response);

    await context.Response.WriteAsJsonAsync(response);
});

app.Run();
