using AngularWebApi.Server.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.ConfigureOptions();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDependencies();
builder.ConfigureCors();
builder.ConfigureDb();

var app = builder.Build();

app.InitDatabase();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseCors(CorsConfiguration.PolicyName);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapUserEndpoint();

app.MapFallbackToFile("/index.html");

app.Run();
