# AngularWebApi

cd AngularWebApi.Infrastructure/

dotnet ef migrations add Initial --startup-project ..\AngularWebApi.Server --context AngularWebApi.Infrastructure.ApplicationDbContext -o Migrations