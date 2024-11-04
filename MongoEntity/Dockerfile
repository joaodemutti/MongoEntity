
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY /MongoEntity.csproj .
RUN dotnet restore ./MongoEntity.csproj
COPY . .
RUN dotnet build ./MongoEntity.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./MongoEntity.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_HTTP_PORTS=8080

ENTRYPOINT ["dotnet", "MongoEntity.dll"]