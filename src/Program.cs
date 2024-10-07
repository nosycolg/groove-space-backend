using Configs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints(); // Ensure FastEndpoints are added first
builder.Services.SwaggerDocument(); // This should be called after adding FastEndpoints
builder.Services.AddAuthorization();
builder.Services.AddAuthentication();

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAnyOrigin", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });

var app = builder.Build();

app.UseCors("AllowAnyOrigin");

app.UseAuthentication();
app.UseAuthorization();

app.UseSwaggerGen(); // Ensure this is called after FastEndpoints are configured
app.UseFastEndpoints();

await MongoConfig.Init(app.Configuration);

app.Run();