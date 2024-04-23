# AngularWebApi

## DB Diagram

![Hello World](./db.png)


cd AngularWebApi.Infrastructure/

dotnet ef migrations add Initial --startup-project ..\AngularWebApi.Server --context AngularWebApi.Infrastructure.ApplicationDbContext -o Migrations
