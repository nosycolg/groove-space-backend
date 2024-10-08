using Configs;
using Amazon.Extensions.NETCore.Setup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices();

builder.Services.AddAWSService<IAmazonS3>(new AWSOptions
{
    Credentials = new Amazon.Runtime.BasicAWSCredentials(
        builder.Configuration["AWS:AccessKey"],
        builder.Configuration["AWS:SecretKey"]
    ),
    Region = Amazon.RegionEndpoint.GetBySystemName(builder.Configuration["AWS:Region"])
});

builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("AllowAnyOrigin");

app.UseAuthentication();
app.UseAuthorization();

app.UseSwaggerGen();
app.UseFastEndpoints();

await MongoConfig.Init(app.Configuration);

app.Run();
