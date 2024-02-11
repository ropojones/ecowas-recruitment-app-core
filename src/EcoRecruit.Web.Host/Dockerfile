FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/EcoRecruit.Web.Host/EcoRecruit.Web.Host.csproj", "src/EcoRecruit.Web.Host/"]
COPY ["src/EcoRecruit.Web.Core/EcoRecruit.Web.Core.csproj", "src/EcoRecruit.Web.Core/"]
COPY ["src/EcoRecruit.Application/EcoRecruit.Application.csproj", "src/EcoRecruit.Application/"]
COPY ["src/EcoRecruit.Core/EcoRecruit.Core.csproj", "src/EcoRecruit.Core/"]
COPY ["src/EcoRecruit.EntityFrameworkCore/EcoRecruit.EntityFrameworkCore.csproj", "src/EcoRecruit.EntityFrameworkCore/"]
WORKDIR "/src/src/EcoRecruit.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/EcoRecruit.Web.Host", "src/EcoRecruit.Web.Host"]
COPY ["src/EcoRecruit.Web.Core", "src/EcoRecruit.Web.Core"]
COPY ["src/EcoRecruit.Application", "src/EcoRecruit.Application"]
COPY ["src/EcoRecruit.Core", "src/EcoRecruit.Core"]
COPY ["src/EcoRecruit.EntityFrameworkCore", "src/EcoRecruit.EntityFrameworkCore"]
WORKDIR "/src/src/EcoRecruit.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "EcoRecruit.Web.Host.dll"]
