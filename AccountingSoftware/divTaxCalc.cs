using System;

namespace AccountingSoftware
{

    public class divTaxCalc

    {

        public double DivTaxCalc(double divIncome, double divAllow, double brDivTaxRate, double hrDivTaxRate, double trDivTaxRate, double brb, double hrb)
        {
            if (divIncome > hrb)
            {
                double trDivTax = (divIncome - hrb) * trDivTaxRate;
                double hrDivTax = (hrb - brb) * hrDivTaxRate;
                double brDivTax = brb * brDivTaxRate;
                double totalDivTax = brDivTax + hrDivTax + trDivTax;
                return totalDivTax;
            }
            else if (divIncome > brb)
            {
                double hrDivTax = (divIncome - brb) * hrDivTaxRate;
                double brDivTax = (brb - divAllow) * brDivTaxRate;
                double totalDivTax = brDivTax + hrDivTax;
                return totalDivTax;
            }
            else if (divIncome > divAllow)
            {
                double totalDivTax = (divIncome - divAllow) * brDivTaxRate;
                return totalDivTax;
            }
            else
            {
                double totalDivTax = 0;
                return totalDivTax;
            }
        }
    }

}