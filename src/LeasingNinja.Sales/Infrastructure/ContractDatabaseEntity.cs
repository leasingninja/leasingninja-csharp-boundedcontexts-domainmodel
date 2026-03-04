using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LeasingNinja.Sales.Domain;

[Table("contracts")]
public class ContractDatabaseEntity
{
	[Key]
	private string number;

	private string lessee;

	private string car;

	[Column("price_amount")]
	private long priceAmount;

	[Column("price_currency")]
	private string priceCurrency;

    private int leaseTermInMonths;

    private double interestPerYear;

	private DateOnly? signDate;

	private ContractDatabaseEntity()
    {
	}

    // Map domain model to EF entity
    public static ContractDatabaseEntity FromDomain(Contract contract)
    {
        return new ContractDatabaseEntity
        {
            number = contract.Number.Value,
            lessee = contract.Lessee.Name,
            car = contract.Car.Name,
            priceAmount = contract.Price.AmountInCents,
            priceCurrency = contract.Price.Currency.ToString(),
            leaseTermInMonths = contract.IsCalculated ? contract.LeaseTerm.NoOfMonths : 0,
            interestPerYear = contract.IsCalculated ? contract.Interest.PerYear : 0,
            signDate = contract.IsSigned ? new DateOnly(contract.SignDate.Year, contract.SignDate.Month, contract.SignDate.Day) : null
        };
    }

    // Map EF entity to domain model
    public Contract ToContract()
    {
        return ContractFactory.RestoreContract(
            ContractNumber.Of(number),
            Customer.Of(lessee),
			Car.Of(car),
            Amount.Of(priceAmount, Enum.Parse<Currency>(priceCurrency)),
            leaseTermInMonths != 0
                    ? LeaseTerm.OfMonths(leaseTermInMonths)
                    : null,
            interestPerYear != 0
                    ? Interest.Of(interestPerYear)
                    : null,
            signDate is DateOnly d
                    ? SignDate.Of(d.Year, d.Month, d.Day)
                    : null
        );
    }
}
