using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbContextInEfMigrations.EfExtensions;

public static class DbContextOptionsBuilderExtensions
{
    public static DbContextOptionsBuilder WithDbContextEnabledMigrations(this DbContextOptionsBuilder dbContextOptionsBuilder)
        => dbContextOptionsBuilder
            .ReplaceService<IMigrationsAssembly, CustomMigrationsAssembly>();
}