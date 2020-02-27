using System;

namespace AccountingSoftware
{
    class Program
    {
        static void Main(string[] args)
        {

            //variables
            double brb = 50000;
            double hrb = 150000;
            double pa = 12500;
            double niAllow = 8562;
            double divAllow = 2000;
            double brIncTaxRate = 0.2;
            double hrIncTaxRate = 0.4;
            double trIncTaxRate = 0.45;
            double brDivTaxRate = 0.075;
            double hrDivTaxRate = 0.325;
            double trDivTaxRate = 0.381;
            double lowerNIRate = 0.12;
            double higherNIRate = 0.02;



            //get income info from user.

            Console.WriteLine("Welcome to your personal 2019-20 Tax Advisor."); 
            Console.WriteLine($"");
            Console.WriteLine("Please enter your income in GBP for the year ended 5th April 2020 in the following categories. If any income source is not applicable to you, please enter 0.");
            Console.WriteLine($"");

            Console.Write("Employment income: ");
            double.TryParse(Console.ReadLine(), out double empIncome);

            Console.Write("Tax deducted at source from employment income: ");
            double.TryParse(Console.ReadLine(), out double empTax);

            Console.Write("Profits from sole trade or partnership: ");
            double.TryParse(Console.ReadLine(), out double stIncome);

            Console.Write("Dividend income: ");
            double.TryParse(Console.ReadLine(), out double divIncome);

            Console.Write("Bank interest received: ");
            double.TryParse(Console.ReadLine(), out double intIncome);

            Console.Write("Tax deducted at source from bank interest received: ");
            double.TryParse(Console.ReadLine(), out double intTax);


            //calculate total income

            double totalIncome = empIncome + divIncome + intIncome + stIncome;
            double nsi = empIncome + intIncome + stIncome;
            

            //calculate total tax deducted at source

            double totalTaxAtSrc = empTax + intTax;


            //call methods

            incTaxCalc i = new incTaxCalc();
            niTaxCalc n = new niTaxCalc();
            divTaxCalc d = new divTaxCalc();

            
            double incomeTax = i.IncTaxCalc(nsi, pa, hrb, brb, brIncTaxRate, hrIncTaxRate, trIncTaxRate);
            double NI = n.NITaxCalc(stIncome, niAllow, lowerNIRate, higherNIRate, brb);
            double divTax = d.DivTaxCalc(divIncome, divAllow, brDivTaxRate, hrDivTaxRate, trDivTaxRate, brb, hrb);


            //calculate total tax due and taxable income

            double totalTax = incomeTax + divTax;
            double taxableIncome = totalIncome - pa;
            double payable = Math.Round(totalTax + NI - totalTaxAtSrc, 2);
            double poa = Math.Round(payable / 2, 2);

            //output

            Console.WriteLine($"");
            Console.WriteLine("Your tax computation:");
            Console.WriteLine($"Total income                    {totalIncome}");
            if (totalIncome > 125000)
            {
                pa = 0;
                Console.WriteLine($"Less: Personal allowance       ({pa})");
            }
            else if (totalIncome > 100000)
            {
                pa = pa - ((totalIncome - 100000) / 2);
                Console.WriteLine($"Less: Personal allowance       ({pa})");
            }
            else
            {
                Console.WriteLine($"Less: Personal allowance       ({pa})");
            }
            Console.WriteLine($"                               ________");
            if (totalIncome > pa)
            {
                Console.WriteLine($"Taxable income                  {taxableIncome}");
            }
            else
            {
                Console.WriteLine($"Taxable income                  nil");
            }
            Console.WriteLine($"");
            Console.WriteLine($"Total tax due for the period    {totalTax}");
            Console.WriteLine($"Total national insurance due    {NI}");
            Console.WriteLine($"Tax paid at source             ({totalTaxAtSrc})");
            Console.WriteLine($"                               ________");
            if (payable > 0)
            {
                Console.WriteLine($"Tax payable by 31st January     {payable}");
            }
            else
            {
                Console.WriteLine($"Refund due                      {payable}");
            }
            Console.WriteLine($"");
            if (payable > 1000)
            {
                Console.WriteLine($"You are also due to make payments on account of {poa} in January and July 2020.");
            }
            else
            {
                Console.WriteLine($"You are not required to make payments on account.");
            }
            Console.WriteLine($"");


        }
    }
}
