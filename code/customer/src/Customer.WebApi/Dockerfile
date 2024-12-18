FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

WORKDIR /src
COPY ["Customer.WebApi.csproj", "Customer.WebApi/"]
RUN dotnet restore "Customer.WebApi/Customer.WebApi.csproj"
COPY . Customer.WebApi/
WORKDIR "/src/Customer.WebApi"
RUN dotnet build "Customer.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "Customer.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 7000

ENTRYPOINT ["dotnet", "Ecommerce.Customer.WebApi.dll"]
