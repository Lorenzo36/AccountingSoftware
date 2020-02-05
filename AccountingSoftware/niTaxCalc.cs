using System;

namespace AccountingSoftware
{

    public class niTaxCalc
    {
        public double NITaxCalc(double stIncome, double niAllow, double lowerNIRate, double higherNIRate, double brb)
        {
            if (stIncome > brb)
            {
                double hrNI = (stIncome - brb) * higherNIRate;
                double brNI = (brb - niAllow) * lowerNIRate;
                double totalNI = hrNI + brNI;
                return totalNI;
            }
            else if (stIncome > niAllow)
            {
                double totalNI = (stIncome - niAllow) * lowerNIRate;
                return totalNI;
            }
            else
            {
                double totalNI = 0;
                return totalNI;
            }
        }

    }

}