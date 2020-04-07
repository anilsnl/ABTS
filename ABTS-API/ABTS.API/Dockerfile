#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ABTS.API/ABTS.API.csproj", "ABTS.API/"]
COPY ["ABTS.Services/ABTS.RedisService/ABTS.RedisService.csproj", "ABTS.Services/ABTS.RedisService/"]
COPY ["ABTS.BLL/ABTS.BLL.csproj", "ABTS.BLL/"]
COPY ["ABTS.DAL/ABTS.DAL.csproj", "ABTS.DAL/"]
COPY ["ABTS.Entities/ABTS.Entities.csproj", "ABTS.Entities/"]
COPY ["ABTS.Services/ABTS.ElasticService/ABTS.ElasticService.csproj", "ABTS.Services/ABTS.ElasticService/"]
RUN dotnet restore "ABTS.API/ABTS.API.csproj"
COPY . .
WORKDIR "/src/ABTS.API"
RUN dotnet build "ABTS.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ABTS.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ABTS.API.dll"]