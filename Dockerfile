#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 1881


FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["src/Dev.Store.Web/Dev.Store.Web.csproj", "src/Dev.Store.Web/"]
COPY ["src/Dev.Store.Application/Dev.Store.Application.csproj", "src/Dev.Store.Application/"]
COPY ["src/Dev.Store.Domain/Dev.Store.Domain.csproj", "src/Dev.Store.Domain/"]
COPY ["src/Dev.Store.Domain.Shared/Dev.Store.Domain.Shared.csproj", "src/Dev.Store.Domain.Shared/"]
COPY ["src/Dev.Store.Application.Contracts/Dev.Store.Application.Contracts.csproj", "src/Dev.Store.Application.Contracts/"]
COPY ["src/Dev.Store.HttpApi/Dev.Store.HttpApi.csproj", "src/Dev.Store.HttpApi/"]
COPY ["src/Dev.Store.EntityFrameworkCore/Dev.Store.EntityFrameworkCore.csproj", "src/Dev.Store.EntityFrameworkCore/"]
#COPY ["src/Dev.Store.Web/Dev.Store.Web/node_modules", "src/Dev.Store.Web/wwwroot/libs"]
RUN dotnet restore "src/Dev.Store.Web/Dev.Store.Web.csproj"
COPY . .
WORKDIR "/src/src/Dev.Store.Web"
RUN dotnet build "Dev.Store.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dev.Store.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false — launch-profile Dev.Store.Web.Production

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dev.Store.Web.dll"]
