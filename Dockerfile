FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy-amd64 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5235
EXPOSE 5235
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release --property:PublishDir=/app
FROM base AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Backend_App_Lenguaje.Presentacion.dll"]