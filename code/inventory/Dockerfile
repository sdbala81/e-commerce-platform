FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

WORKDIR /src

# Copy the required build configuration and NuGet settings
COPY ["src", "."]

RUN dotnet restore "Inventory.WebApi/Inventory.WebApi.csproj"
RUN dotnet build "Inventory.WebApi/Inventory.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet publish "Inventory.WebApi/Inventory.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8000

ENTRYPOINT ["dotnet", "Ecommerce.Inventory.WebApi.dll"]