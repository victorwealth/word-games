#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["BlazorWordGames/Server/BlazorWordGames.Server.csproj", "BlazorWordGames/Server/"]
COPY ["BlazorWordGames/Client/BlazorWordGames.Client.csproj", "BlazorWordGames/Client/"]
COPY ["BlazorWordGames/Shared/BlazorWordGames.Shared.csproj", "BlazorWordGames/Shared/"]
RUN dotnet restore "BlazorWordGames/Server/BlazorWordGames.Server.csproj"
COPY . .
WORKDIR "/src/BlazorWordGames/Server"
RUN dotnet build "BlazorWordGames.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorWordGames.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorWordGames.Server.dll"]