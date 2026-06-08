FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["LiveMatchAPI/LiveMatchAPI.csproj", "LiveMatchAPI/"]
COPY ["LiveMatchApplication/LiveMatchApplication.csproj", "LiveMatchApplication/"]
COPY ["LiveMatchDomain/LiveMatchDomain.csproj", "LiveMatchDomain/"]
COPY ["LiveMatchInfrastructure/LiveMatchInfrastructure.csproj", "LiveMatchInfrastructure/"]
RUN dotnet restore "LiveMatchAPI/LiveMatchAPI.csproj"
COPY . .
WORKDIR "/src/LiveMatchAPI"
RUN dotnet build "LiveMatchAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LiveMatchAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LiveMatchAPI.dll"]