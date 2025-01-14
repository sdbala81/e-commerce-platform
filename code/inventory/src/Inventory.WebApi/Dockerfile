FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

WORKDIR /src
COPY ["code/inventory/src/Inventory.WebApi/Inventory.WebApi.csproj", "Inventory.WebApi/"]
RUN dotnet restore "Inventory.WebApi/Inventory.WebApi.csproj"

COPY code/inventory/src/Inventory.WebApi/ Inventory.WebApi/

RUN ls -R Inventory.WebApi/

WORKDIR "/src/Inventory.WebApi"

RUN dotnet build "Inventory.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "Inventory.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 8000

ENTRYPOINT ["dotnet", "Ecommerce.Inventory.WebApi.dll"]
