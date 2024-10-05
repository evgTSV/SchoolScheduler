FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR "/src/SchoolScheduler"
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY "SchoolScheduler/SchoolScheduler.fsproj" .
COPY global.json .
RUN dotnet restore "SchoolScheduler/SchoolScheduler.fsproj"
RUN dotnet build "SchoolScheduler.fsproj" -c $BUILD_CONFIGURATION -o /app/build

FROM base AS final
WORKDIR /publish
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "SchoolScheduler.dll"]