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

## How-to run

### Back-end APIs

The following commands are given with the private back-end API as an example.

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
docker run -d -p 8080:80 --name opus_private opus/user-mgmt/private
docker inspect --format='{{json .State.Health}}' opus_private
```
