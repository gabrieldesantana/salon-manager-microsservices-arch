#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER app
#WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081
#
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["SalonManager.Customers/SalonManager.Customers.csproj", "SalonManager.Customers/"]
#RUN dotnet restore "./SalonManager.Customers/SalonManager.Customers.csproj"
#COPY . .
#WORKDIR "/src/SalonManager.Customers"
#RUN dotnet build "./SalonManager.Customers.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./SalonManager.Customers.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "SalonManager.Customers.dll"]

# Use a imagem base do ASP.NET Core runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Use a imagem base do SDK do .NET Core para compilar e publicar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copie o arquivo .csproj e restaure as dependências
COPY *.csproj ./

# Copie todos os arquivos e compile a aplicação
COPY . ./
RUN dotnet build -c Release -o /app/build

# Publique a aplicação
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# Use a imagem base do runtime para rodar a aplicação
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SalonManager.Customers.dll"]