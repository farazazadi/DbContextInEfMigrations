// Source: https://github.com/dotnet/efcore/blob/main/src/Shared/Check.cs

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DbContextInEfMigrations.EfExtensions;

[DebuggerStepThrough]
internal static class Check
{
    [ContractAnnotation("value:null => halt")]
    [return: System.Diagnostics.CodeAnalysis.NotNull]
    public static T NotNull<T>([NoEnumeration][AllowNull][System.Diagnostics.CodeAnalysis.NotNull] T value, [InvokerParameterName] string parameterName)
    {
        if (value is null)
        {
            NotEmpty(parameterName, nameof(parameterName));

            throw new ArgumentNullException(parameterName);
        }

        return value;
    }

    [ContractAnnotation("value:null => halt")]
    public static string NotEmpty([System.Diagnostics.CodeAnalysis.NotNull] string? value, [InvokerParameterName] string parameterName)
    {
        if (value is null)
        {
            NotEmpty(parameterName, nameof(parameterName));

            throw new ArgumentNullException(parameterName);
        }

        if (value.Trim().Length == 0)
        {
            NotEmpty(parameterName, nameof(parameterName));

            throw new ArgumentException(AbstractionsStrings.ArgumentIsEmpty(parameterName));
        }

        return value;
    }

}