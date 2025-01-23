

#build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY ForecastAPI ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

#RUNTIME
#Imagen base de .net
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
COPY --from=build /app/out ./
EXPOSE 7232
ENTRYPOINT ["dotnet","ForecastAPI.dll"]


