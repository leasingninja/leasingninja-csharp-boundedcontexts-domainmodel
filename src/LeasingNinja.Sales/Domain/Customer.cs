using System.Text.RegularExpressions;
using static System.Diagnostics.Debug;
using NMolecules.DDD;

namespace LeasingNinja.Sales.Domain;

[ValueObject]
public readonly record struct Customer(string Name)
{
    public static Customer Of(string name)
    {
        Assert(IsValid(name));
        return new Customer(name);
    }

    public static bool IsValid(string nameString) => Regex.IsMatch(nameString, @"^\p{L}+(\s\p{L}+)*$");
}
