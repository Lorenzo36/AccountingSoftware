using System;

namespace AccountingSoftware
{
    public class incTaxCalc
    {

        public double IncTaxCalc(double nsi, double pa, double hrb, double brb, double brIncTaxRate, double hrIncTaxRate, double trIncTaxRate)
        {
                if (nsi > hrb)
                {
                    double trTax = (nsi - hrb) * trIncTaxRate;
                    double hrTax = (hrb - brb) * hrIncTaxRate;
                    double brTax = brb * brIncTaxRate;
                    double totalIncTax = brTax + hrTax + trTax;
                    return totalIncTax;
                }
                else if (nsi > brb)
                {
                    double hrTax = (nsi - brb) * hrIncTaxRate;
                    double brTax = (brb - pa) * brIncTaxRate;
                    double totalIncTax = brTax + hrTax;
                    return totalIncTax;
                }
                else if (nsi > pa)
                {
                    double totalIncTax = (nsi - pa) * brIncTaxRate;
                    return totalIncTax;
                }
                else
                {
                    double totalIncTax = 0;
                    return totalIncTax;
                }
        }


    }


}