FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SchoolScheduler/SchoolScheduler.fsproj", "SchoolScheduler/"]
RUN dotnet restore "SchoolScheduler/SchoolScheduler.fsproj"
COPY . .
WORKDIR "/src/SchoolScheduler"
RUN dotnet build "SchoolScheduler.fsproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SchoolScheduler.fsproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SchoolScheduler.dll"]
