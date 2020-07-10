FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["src/backend/SwNaQuarentena.Api.csproj", "/src/backend/"]
RUN dotnet restore "backend/SwNaQuarentena.Api.csproj"
COPY src/. /src/.

WORKDIR /src
RUN dotnet build "backend/SwNaQuarentena.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "backend/SwNaQuarentena.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SwNaQuarentena.Api.dll"]

