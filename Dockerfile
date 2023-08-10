FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DOTNET6-COURSE-WEB-API/DOTNET6-COURSE-WEB-API.csproj", "DOTNET6-COURSE-WEB-API/"]
RUN dotnet restore "DOTNET6-COURSE-WEB-API/DOTNET6-COURSE-WEB-API.csproj"
COPY . .
WORKDIR "/src/DOTNET6-COURSE-WEB-API"
RUN dotnet build "DOTNET6-COURSE-WEB-API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DOTNET6-COURSE-WEB-API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DOTNET6-COURSE-WEB-API.dll"]
