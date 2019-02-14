# User management - Softeam Opus

User management application for Softeam Opus, consisting in:
* a front-end app with web components
* a back-end API in .Net Core / C#
    * a private, secure API for the front-end
    * a public API for external applications 

## Directory structure

<dl>
    <dt>`app/`<dt>
    <dd>Front-end application</dd>
</dl>
<dl>
    <dt>`api/`<dt>
    <dd>Back-end API</dd>
</dl>

## Technology stack

<dl>
    <dt>Front-end API</dt>
    <dd>TBD. (probably LitElement with Polymer)</dd>
</dl>
<dl>
    <dt>Back-end API</dt>
    <dd>.NET Core, PostgreSQL, Docker</dd>
</dl>


## How-to run

### Setup the database

The applications requires a PostgreSQL database to run.

A local database named `user_mgmt_db` can be spun up quickly with Docker:

```powershell
cd api/db
docker build -t opus/user-mgmt/db .
docker run -d -p 5432:5432 --name postgres_dev -e POSTGRES_PASSWORD=****** opus/user-mgmt/db
```

The database will be accessible on port 5432/tcp, user `postgres`.

### Run back-end APIs

Database credentials for the apps are configured in `appsettings.json`.

The following commands are given with the private back-end API as an example.

The same commands apply to public back-end API, with some small adaptations (folders, ports, etc.).

#### Locally

The following will serve the private API at https://localhost:44312

```powershell
cd api/private
dotnet run --project src/PrivateApi/PrivateApi.csproj

# liveness test (optional)
curl https://localhost:44312/healthz
```

#### With Docker

The following will serve the private API at http://localhost:8080

```powershell
cd api/private
docker build -t opus/user-mgmt/private .
docker run -d -p 8080:80 --name user_mgmt_private -e "ASPNETCORE_ENVIRONMENT=Staging" opus/user-mgmt/private
```

When running the local database `postgres_dev` as a docker container, a docker network is required to allow connection between containers.

```powershell
docker network create my-net
docker network connect my-net postgres_dev
docker network connect my-net user_mgmt_private
```

Liveness test (optional)

```
docker inspect --format='{{json .State.Health}}' user_mgmt_private
```

Or browse http://localhost:8080/healthz

### Run front-end app

TODO