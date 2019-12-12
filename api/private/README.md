# User management - Back-end private API

A private, secure API for user management application front-ends.

## Directory structure

TODO

## Technology stack

<dl>
    <dt>Application framework</dt>
    <dd>.NET Core</dd>
    <dt>ORM</dt>
    <dd>Entity Framework Core</dd>
    <dt>Database</dt>
    <dd>PostgreSQL</dd>
</dl>

## Database migrations

TODO

Design-time configuration and credentials for the apps are configured in `UserMgmtContextFactory` (remember to replace the ****** with the previously chosen password)

```powershell
dotnet ef migrations add InitialCreate
```
