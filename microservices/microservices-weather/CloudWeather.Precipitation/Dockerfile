FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

COPY ./CloudWeather.Precipitation.csproj .
RUN dotnet restore "CloudWeather.Precipitation.csproj" -r linux-x64 /p:PublishReadyToRun=true

COPY . .
RUN dotnet publish "CloudWeather.Precipitation.csproj" -c Release -o /app -r linux-x64 --self-contained true --no-restore /p:PublishTrimmed=true /p:PublishReadyToRun=true /p:PublishSingleFile=true

FROM mcr.microsoft.com/dotnet/runtime-deps:6.0-bullseye-slim-amd64
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT ["./CloudWeather.Precipitation"]