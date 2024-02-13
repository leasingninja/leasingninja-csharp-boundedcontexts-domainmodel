using System;
using NMolecules.DDD;

namespace LeasingNinja.Sales.Domain;

/**
* Simulates the famous HP12c calculator that is widely used in the leasing industry.
*/
[Service]
public class FinancialCalculator
{
    public static double pmt(double n, double iInPercent, double pv, double fv, double s)
    {
        double i = iInPercent / 100;

        if (i == 0)
        {
            return (-1 * pv - fv) / n;
        }

        return (i * ( fv + pv * Math.Pow(1 + i, n))) / ((1 + i * s) * (1 - Math.Pow(1 + i, n)));
    }
}