# User management - Back-end private API

A private, secure API for user management application front-ends.

## Directory structure

<dl>
    <dt>`src/Domain/`<dt>
    <dd>Application Domain (business logic)</dd>
    <dt>`src/PrivateApi/`<dt>
    <dd>Application Controllers and orchestration</dd>
    <dt>`api/DatabaseInfrastructure/`<dt>
    <dd>Database adapters</dd>
    <dt>`doc/`<dt>
    <dd>OpenAPI documentation</dd>
    <dt>`test/`<dt>
    <dd>Unit tests, BDD tests</dd>
</dl>

## Technology stack

<dl>
    <dt>Application framework</dt>
    <dd>ASP.NET Core</dd>
    <dt>ORM</dt>
    <dd>Entity Framework Core</dd>
    <dt>Database</dt>
    <dd>PostgreSQL</dd>
    <dt>Tests</dt>
    <dd>xUnit and SpecFlow</dd>
</dl>

## Run the private back-end API

Database credentials for the apps are configured in `appsettings.*.json` (remember to replace the \*\*\*\*\*\* with the previously chosen
password)

### Run locally

The following will serve the private API at https://localhost:44312

```powershell
dotnet run --project src/PrivateApi/PrivateApi.csproj

# liveness test (optional)
curl https://localhost:44312/healthz
```

## Database migrations

A code first approach has been selected for design.

Database migrations/updates are configured to be performed automatically when the application starts.

### Add a new migration

Design-time configuration and credentials for the apps are configured in `UserMgmtContextFactory` 
(remember to replace the \*\*\*\*\*\* with the previously chosen password)

```powershell
dotnet ef migrations add NewMigrationName
```

### Reset migrations

In case of emergency, reset all migrations and start again with a clean empty state.

```powershell
dotnet ef database update InitialCreate
```

And then remove the faulty migrations one by one

```powershell
dotnet ef migrations remove
dotnet ef migrations remove
dotnet ef migrations remove
...
```

## API documentation

Documentation on methods/arguments of this API is available in OpenAPI format.

By design, the OpenAPI documentation is written first (and not auto-generated from code)
It __has__ to be updated and published prior to any modification.

### Test interface (Swagger UI)

A test interface is available via Docker.
The following will serve the interface at http://localhost:42081

```powershell
docker build -t user-mgmt/private/doc doc
docker run -d -p 42081:8080 --name user_mgmt_swagger_private user-mgmt/private/doc
```
