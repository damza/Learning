using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualTaxCalculator.BusinessLogic
{
    public class CalculateTax : ICalculateTax
    {
        public decimal CalculateFlatValueTax(decimal annualIncome)
        {
            decimal taxResult = 10000;

            if(annualIncome < 200000M)
            {
                taxResult = annualIncome * 0.05M;
            }

            return taxResult;
        }

        public decimal CalculateFlatRateTax(decimal annualIncome)
        {
            return annualIncome * 0.175M;
        }

        public decimal CalculateProgressiveTax(decimal annualIncome)
        {
            decimal taxResult = 0;

            if (annualIncome < 8351)
            {
                taxResult = GetTenPercent(annualIncome);
            }
            else
            {
                if (annualIncome < 33951)
                {
                    taxResult += GetTenPercent(8350);
                    taxResult += GetFifteenPercent(annualIncome - 8350);
                }
                else
                {
                    if (annualIncome < 82251)
                    {
                        taxResult += GetTenPercent(8350);
                        taxResult += GetFifteenPercent(33950 - 8350);
                        taxResult += GetTwentyFivePercent(annualIncome - 33950);
                    }
                    else
                    {
                        if(annualIncome < 171551)
                        {
                            taxResult += GetTenPercent(8350);
                            taxResult += GetFifteenPercent(33950 - 8350);
                            taxResult += GetTwentyFivePercent(82250 - 33950);
                            taxResult += GetTwentyEightPercent(annualIncome - 82250);
                        }
                        else
                        {
                            if(annualIncome < 372951)
                            {
                                taxResult += GetTenPercent(8350);
                                taxResult += GetFifteenPercent(33950 - 8350);
                                taxResult += GetTwentyFivePercent(82250 - 33950);
                                taxResult += GetTwentyEightPercent(171550 - 82250);
                                taxResult += GetThirtyThreePercent(annualIncome - 171550);
                            }
                            else
                            {
                                if (annualIncome >= 372951)
                                {
                                    taxResult += GetTenPercent(8350);
                                    taxResult += GetFifteenPercent(33950 - 8350);
                                    taxResult += GetTwentyFivePercent(82250 - 33950);
                                    taxResult += GetTwentyEightPercent(171550 - 82250);
                                    taxResult += GetThirtyThreePercent(372950 - 171550);
                                    taxResult += GetThirtyFivePercent(annualIncome - 372950);
                                }
                            }
                        }
                    }
                }
            }

            return taxResult;
        }

        private decimal GetTenPercent(decimal annualIncomePart)
        {
            return annualIncomePart * 0.10M;
        }

        private decimal GetFifteenPercent(decimal annualIncomePart)
        {
            return annualIncomePart * 0.15M;
        }

        private decimal GetTwentyFivePercent(decimal annualIncomePart)
        {
            return annualIncomePart * 0.25M;
        }

        private decimal GetTwentyEightPercent(decimal annualIncomePart)
        {
            return annualIncomePart * 0.28M;
        }

        private decimal GetThirtyThreePercent(decimal annualIncomePart)
        {
            return annualIncomePart * 0.33M;
        }

        private decimal GetThirtyFivePercent(decimal annualIncomePart)
        {
            return annualIncomePart * 0.35M;
        }
        
    }
}
