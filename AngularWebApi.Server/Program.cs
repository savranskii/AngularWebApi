using AngularWebApi.Server.Extensions.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.ConfigureOptions();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDependencies();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureExceptionHandler();
builder.ConfigureRateLimit();
builder.ConfigureCors();
builder.ConfigureDb();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseCors(CorsConfiguration.PolicyName);
app.UseExceptionHandler(_ => { });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapUserEndpoint();
app.MapLocationEndpoint();

app.MapFallbackToFile("/index.html");

app.Run();

public partial class Program
{
}