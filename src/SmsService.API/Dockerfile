#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/SmsService.API/SmsService.API.csproj", "src/SmsService.API/"]
COPY ["src/SmsService.Services/SmsService.Services.csproj", "src/SmsService.Services/"]
COPY ["SmsService.DAL/SmsService.Model.csproj", "SmsService.DAL/"]
RUN dotnet restore "src/SmsService.API/SmsService.API.csproj"
COPY . .
WORKDIR "/src/src/SmsService.API"
RUN dotnet build "SmsService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SmsService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmsService.API.dll"]