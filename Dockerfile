# Stage1: ビルド用コンテナ
FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app
COPY WeatherApi/*.csproj ./
RUN dotnet restore
# Copy everything else and build
COPY WeatherApi/. ./
RUN dotnet publish -c Release -o out

# Stage2: 実行用コンテナ
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 5000
ENTRYPOINT ["dotnet", "WeatherApi.dll"]