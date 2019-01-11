# Compile, test and publish using SDK
FROM microsoft/dotnet:2.2-sdk AS build-env
WORKDIR /app

COPY src/PrivateApi/*.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out src/PrivateApi/*.csproj

# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/src/PrivateApi/out .

# Health check
HEALTHCHECK CMD curl --fail -s http://localhost:80/healthz || exit 1

ENTRYPOINT ["dotnet", "PrivateApi.dll"]