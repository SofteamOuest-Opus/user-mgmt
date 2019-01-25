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

Database credentials for the apps are setup in `appsettings.json`.

### Setup Back-end APIs

The following command examples are given with the private back-end API.

The same commands apply to public back-end API, with some small adaptations (folders, ports, etc.).

#### Locally

The following will serve the private API at https://localhost:44312

```powershell
cd api/private
dotnet run --project src/PrivateApi/PrivateApi.csproj
```

#### With Docker

The following will serve the private API at http://localhost:8080

```powershell
cd api/private
docker build -t opus/user-mgmt/private .
docker run -d -p 8080:80 --name user_mgmt_private opus/user-mgmt/private
docker inspect --format='{{json .State.Health}}' user_mgmt_private
```
