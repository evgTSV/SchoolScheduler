FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR "/src/SchoolScheduler"
COPY "SchoolScheduler/SchoolScheduler.fsproj" .
RUN dotnet restore
COPY "SchoolScheduler" .
COPY global.json .
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 as runtime
WORKDIR /publish
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "SchoolScheduler.dll"]