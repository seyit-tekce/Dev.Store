#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["src/Dev.Store.DbMigrator/Dev.Store.DbMigrator.csproj", "src/Dev.Store.DbMigrator/"]
COPY ["src/Dev.Store.Application.Contracts/Dev.Store.Application.Contracts.csproj", "src/Dev.Store.Application.Contracts/"]
COPY ["src/Dev.Store.Domain.Shared/Dev.Store.Domain.Shared.csproj", "src/Dev.Store.Domain.Shared/"]
COPY ["src/Dev.Store.EntityFrameworkCore/Dev.Store.EntityFrameworkCore.csproj", "src/Dev.Store.EntityFrameworkCore/"]
COPY ["src/Dev.Store.Domain/Dev.Store.Domain.csproj", "src/Dev.Store.Domain/"]
RUN dotnet restore "src/Dev.Store.DbMigrator/Dev.Store.DbMigrator.csproj"
COPY . .
WORKDIR "/src/src/Dev.Store.DbMigrator"
RUN dotnet build "Dev.Store.DbMigrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dev.Store.DbMigrator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dev.Store.DbMigrator.dll"]