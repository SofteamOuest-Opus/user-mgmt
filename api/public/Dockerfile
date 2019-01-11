# Compile, test and publish using SDK
FROM microsoft/dotnet:2.2-sdk AS build-env
WORKDIR /app

COPY src/PublicApi/*.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out src/PublicApi/*.csproj
RUN dotnet test public.sln

# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/src/PublicApi/out .

# Health check
HEALTHCHECK CMD curl --fail -s http://localhost:80/healthz || exit 1

ENTRYPOINT ["dotnet", "PublicApi.dll"]