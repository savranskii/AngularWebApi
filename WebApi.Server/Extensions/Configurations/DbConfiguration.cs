using Microsoft.EntityFrameworkCore;
using WebApi.Infrastructure;

namespace WebApi.Server.Extensions.Configurations;

public static class DbConfiguration
{
    public static void ConfigureDb(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("SqlLite")));
    }
}