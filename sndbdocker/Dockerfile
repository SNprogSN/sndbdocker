#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["sndbdocker/sndbdocker.csproj", "sndbdocker/"]
RUN dotnet restore "sndbdocker/sndbdocker.csproj"
COPY . .
WORKDIR "/src/sndbdocker"
RUN dotnet build "sndbdocker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "sndbdocker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Create the uploads directory within the container
RUN mkdir -p /app/uploads/files

ENTRYPOINT ["dotnet", "sndbdocker.dll"]]