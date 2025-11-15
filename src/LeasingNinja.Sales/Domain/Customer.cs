using System.Text.RegularExpressions;
using static System.Diagnostics.Debug;

using NMolecules.DDD;

namespace LeasingNinja.Sales.Domain;

[ValueObject]
public readonly record struct Customer
{
    public string Name { get; init; }

    public Customer(string name)
    {
        Assert(IsValid(name));
        
        Name = name;
    }

    public static Customer Of(string name) => new(name);

    public static bool IsValid(string nameString) 
    {
        return Regex.IsMatch(nameString, @"^\p{L}+(\s\p{L}+)*$");
    }
}
