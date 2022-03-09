FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
COPY /bin/Debug/netcoreapp3.1/ app/
WORKDIR /app
EXPOSE 5000
ENTRYPOINT ["dotnet", "api.dll"]