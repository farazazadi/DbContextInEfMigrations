using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Internal;

namespace DbContextInEfMigrations.EfExtensions;

/// <inheritdoc />
public class CustomMigrationsAssembly : MigrationsAssembly
{
    private readonly ICurrentDbContext _currentContext;
    

    /// <inheritdoc />
    public CustomMigrationsAssembly(
        ICurrentDbContext currentContext,
        IDbContextOptions options,
        IMigrationsIdGenerator idGenerator,
        IDiagnosticsLogger<DbLoggerCategory.Migrations> logger
        ) : base(currentContext, options, idGenerator, logger)
    {

        _currentContext = currentContext;
    }




    /// <inheritdoc />
    public override Migration CreateMigration(TypeInfo migrationClass, string activeProvider)
    {
        Check.NotNull(activeProvider, nameof(activeProvider));

        ConstructorInfo? constructorWithDbContextParameter = 
            migrationClass
            .GetConstructors()
            .FirstOrDefault(constructorInfo =>
            {
                ParameterInfo[] parameters = constructorInfo.GetParameters();

                return parameters.Count() == 1 &&
                       parameters.First().ParameterType.IsSubclassOf(typeof(DbContext));
            });


        if (constructorWithDbContextParameter is not null)
        {
            Migration instance = (Migration)constructorWithDbContextParameter.Invoke(new object?[] { _currentContext.Context });
            instance.ActiveProvider = activeProvider;

            return instance;
        }

        return base.CreateMigration(migrationClass, activeProvider);
    }
}