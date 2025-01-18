FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Vanguardium.Api/Vanguardium.Api.csproj", "Vanguardium.Api/"]
COPY ["Vanguardium.ApplicationService/Vanguardium.ApplicationService.csproj", "Vanguardium.ApplicationService/"]
COPY ["Vanguardium.Domain/Vanguardium.Domain.csproj", "Vanguardium.Domain/"]
COPY ["Vanguardium.Infra/Vanguardium.Infra.csproj", "Vanguardium.Infra/"]
RUN dotnet restore "Vanguardium.Api/Vanguardium.Api.csproj"
COPY . .
WORKDIR "/src/Vanguardium.Api"
RUN dotnet build "Vanguardium.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Vanguardium.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Vanguardium.Api.dll"]
