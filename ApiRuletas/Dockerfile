FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["ApiRuletas/ApiRuletas.csproj", "ApiRuletas/"]

RUN dotnet restore "ApiRuletas/ApiRuletas.csproj"
COPY . .
WORKDIR "/src/ApiRuletas"
RUN dotnet build "ApiRuletas.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiRuletas.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiRuletas.dll"]