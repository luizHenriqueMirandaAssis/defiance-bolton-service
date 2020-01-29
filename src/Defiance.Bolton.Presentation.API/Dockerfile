FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Defiance.Bolton.Presentation.API/Defiance.Bolton.Presentation.API.csproj", "src/Defiance.Bolton.Presentation.API/"]
COPY ["src/Defiance.Bolton.Infrastructure.Ioc/Defiance.Bolton.Infrastructure.Ioc.csproj", "src/Defiance.Bolton.Infrastructure.Ioc/"]
COPY ["src/Defiance.Bolton.Domain/Defiance.Bolton.Domain.csproj", "src/Defiance.Bolton.Domain/"]
COPY ["src/Defiance.Bolton.Infrastructure.Data/Defiance.Bolton.Infrastructure.Data.csproj", "src/Defiance.Bolton.Infrastructure.Data/"]
COPY ["src/Defiance.Bolton.Application/Defiance.Bolton.Application.csproj", "src/Defiance.Bolton.Application/"]
COPY ["src/Defiance.Bolton.Infrastructure.Arquivei/Defiance.Bolton.Infrastructure.Arquivei.csproj", "src/Defiance.Bolton.Infrastructure.Arquivei/"]
RUN dotnet restore "src/Defiance.Bolton.Presentation.API/Defiance.Bolton.Presentation.API.csproj"
COPY . .
WORKDIR "/src/src/Defiance.Bolton.Presentation.API"
RUN dotnet build "Defiance.Bolton.Presentation.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Defiance.Bolton.Presentation.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Defiance.Bolton.Presentation.API.dll"]