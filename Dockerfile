#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MyDeveloperTools.ServerApp/MyDeveloperTools.ServerApp.csproj", "MyDeveloperTools.ServerApp/"]
COPY ["MyDeveloperTools.Core/MyDeveloperTools.Core.csproj", "MyDeveloperTools.Core/"]
RUN dotnet restore "MyDeveloperTools.ServerApp/MyDeveloperTools.ServerApp.csproj"
COPY . .
WORKDIR "/src/MyDeveloperTools.ServerApp"
RUN dotnet build "MyDeveloperTools.ServerApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyDeveloperTools.ServerApp.csproj" -c Release -o /app/publish /p:UseAppHost=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyDeveloperTools.ServerApp.dll"]