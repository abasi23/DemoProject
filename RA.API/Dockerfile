#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RA.API/RA.API.csproj", "RA.API/"]
COPY ["RA.Config/RA.Config.csproj", "RA.Config/"]
COPY ["RA.Infrastructure/RA.Infrastructure.csproj", "RA.Infrastructure/"]
COPY ["RA.Application/RA.Application.csproj", "RA.Application/"]
COPY ["RA.Domain/RA.Domain.csproj", "RA.Domain/"]
RUN dotnet restore "RA.API/RA.API.csproj"
COPY . .
WORKDIR "/src/RA.API"
RUN dotnet build "RA.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RA.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RA.API.dll"]