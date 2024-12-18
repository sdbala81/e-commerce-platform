FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5002
EXPOSE 5003

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Inventory.WebApi/Inventory.WebApi.csproj", "src/Inventory.WebApi/"]
RUN dotnet restore "src/Inventory.WebApi/Inventory.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Inventory.WebApi"
RUN dotnet build "Inventory.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Inventory.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecommerce.Inventory.WebApi.dll"]
