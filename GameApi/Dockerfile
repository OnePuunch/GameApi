#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 10000
EXPOSE 10000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GameApi/GameApi.csproj", "GameApi/"]
RUN dotnet restore "GameApi/GameApi.csproj"
COPY . .
WORKDIR "/src/GameApi"
RUN dotnet build "GameApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GameApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameApi.dll"]