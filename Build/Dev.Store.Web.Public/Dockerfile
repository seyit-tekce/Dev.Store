#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 1002


FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["src/Dev.Store.Web.Public/Dev.Store.Web.Public.csproj", "src/Dev.Store.Web.Public/"]
COPY ["src/Dev.Store.Application/Dev.Store.Application.csproj", "src/Dev.Store.Application/"]
COPY ["src/Dev.Store.Domain/Dev.Store.Domain.csproj", "src/Dev.Store.Domain/"]
COPY ["src/Dev.Store.Domain.Shared/Dev.Store.Domain.Shared.csproj", "src/Dev.Store.Domain.Shared/"]
COPY ["src/Dev.Store.Application.Contracts/Dev.Store.Application.Contracts.csproj", "src/Dev.Store.Application.Contracts/"]
COPY ["src/Dev.Store.HttpApi/Dev.Store.HttpApi.csproj", "src/Dev.Store.HttpApi/"]
COPY ["src/Dev.Store.EntityFrameworkCore/Dev.Store.EntityFrameworkCore.csproj", "src/Dev.Store.EntityFrameworkCore/"]
COPY ["src/Modules/SiteContent/Dev.Store.Web.UI.SiteContent/Dev.Store.Web.UI.csproj", "src/Modules/SiteContent/Dev.Store.Web.UI.SiteContent/"]
COPY ["src/Modules/Themes/Dev.Store.AspNetCore.Mvc.UI.Theme.MultiKart/Dev.Store.AspNetCore.Mvc.UI.Theme.MultiKart.csproj", "src/Modules/Themes/Dev.Store.AspNetCore.Mvc.UI.Theme.MultiKart/"]
RUN dotnet restore "src/Dev.Store.Web.Public/Dev.Store.Web.Public.csproj"
COPY . .
WORKDIR "/src/src/Dev.Store.Web.Public"
RUN dotnet build "Dev.Store.Web.Public.csproj" -c Release -o /app/build



RUN apt-get update -q && apt-get install -qy nodejs npm
COPY ./install-libs.sh /install-libs.sh
RUN chmod +x /install-libs.sh
RUN /install-libs.sh


FROM build AS publish
RUN dotnet publish "Dev.Store.Web.Public.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dev.Store.Web.Public.dll","--launch-profile Dev.Store.Web.Public.Production"]
