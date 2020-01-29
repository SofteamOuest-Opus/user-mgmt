# User management - Softeam Opus

User management application for Softeam Opus, consisting in:
* a front-end app with web components
* a back-end API in .Net Core / C#
    * a private, secure API for the front-end
    * a public API for external applications 

## Documentation

Comprehensive specifications can be found in [this Github repo](https://github.com/SofteamOuest-Opus/specs/tree/master/user-mgmt)
along with description of general application architecture and interface mockups. 

## Directory structure

<dl>
    <dt>`app/`<dt>
    <dd>Front-end application</dd>
    <dt>`api/private/`<dt>
    <dd>Back-end private API</dd>
    <dt>`api/public/`<dt>
    <dd>Back-end public API</dd>
    <dt>`infrastructure/`<dt>
    <dd>Local scripts for setting up back-end infrastructure</dd>
</dl>

## Technology stack

<dl>
    <dt>Front-end API</dt>
    <dd>TODO</dd>
    <dt>Back-end API</dt>
    <dd>.NET Core, PostgreSQL</dd>
</dl>


## How-to run

### Infrastructure

To run, the applications require:
- a PostgreSQL database for storage
- a Keycloak instance for authentication (TODO)
- a Apache Kafka instance for messaging (TODO)

A local development infrastructure, with a default setup, can be spun up quickly with Docker. Just replace \*\*\*\*\*\* with the passwords of your choice,

And then:
```powershell
docker-compose --file infrastructure/docker-compose.yaml --project-name user_mgmt_infra up --build --detach
```

#### Local database

The database will be accessible on port 5432/tcp, user `postgres` and password of your choice.

#### Keycloak

TODO

#### Kafka

TODO

#### Stopping the infrastructure

```powershell
docker-compose --file infrastructure/docker-compose.yaml --project-name user_mgmt_infra down
```

### Run the private back-end API

More comprehensive instructions for running and building the private API can be found 
in the [`api/private/` directory](./api/private/README.md).

Database credentials for the apps are configured in `appsettings.*.json` (remember to replace the \*\*\*\*\*\* with the previously chosen password)

#### Run locally

The following will serve the private API at https://localhost:44312

```powershell
cd api/private
dotnet run --project src/PrivateApi/PrivateApi.csproj

# liveness test (optional)
curl https://localhost:44312/healthz
```

#### Test interface (Swagger UI)

Documentation on methods/arguments of this API is available in OpenAPI format.

A test interface is available via Docker. 
The following will serve the interface at http://localhost:42081

```powershell
docker build -t user-mgmt/private/doc api/private/doc
docker run -d -p 42081:8080 --name user_mgmt_swagger_private user-mgmt/private/doc
```

### Run the public back-end API

TODO

### Run the front-end app

TODO

## How to Docker

TODO
