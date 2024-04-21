using AngularWebApi.Infrastructure;

namespace AngularWebApi.Server.Extensions;

public static class DbConfiguration
{
    public static void ConfigureDb(this WebApplicationBuilder builder)
    {
        builder.Services.AddSqlite<ApplicationDbContext>(builder.Configuration.GetConnectionString("SqlLite"));
    }
}
