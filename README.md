# DbContextInEfMigrations

This project demonstrates how to inject and access `DbContext` within Entity Framework Core `migrations`.

#### However, note that you should avoid this for two important reasons:

* To achieve this, you have to override the `CreateMigration` method of the `MigrationsAssembly` class, which is an internal API. Internal APIs are meant to support EF Core's infrastructure and are not subject to the same compatibility standards as public APIs. This means they can be changed or removed without notice in any release, potentially causing application failures when upgrading to a new version of EF Core.

* During the migration process, your model might not match the database structure due to pending migrations, which can lead to unexpected behavior.