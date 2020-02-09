using IndividualTaxCalculator.BusinessLogic;
using IndividualTaxCalculator.Models;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;


namespace IndividualTaxCalculatorTests
{
    public class TaxTests
    {
        private readonly IDataLayer _dataLayer;
        private readonly ICalculateTax _calculateTax;

        public TaxTests()
        {
            var services = new ServiceCollection();

            services.AddTransient<ITaxTypeRepository, TaxTypeRepository>();
            services.AddTransient<ITaxCalculationRepository, TaxCalculationRepository>();

            services.AddSingleton<ICalculateTax, CalculateTax>();
            services.AddSingleton<IDataLayer, DataLayer>();

            var serviceProvider = services.BuildServiceProvider();

            //_dataLayer = serviceProvider.GetService<IDataLayer>();
            _calculateTax = serviceProvider.GetService<ICalculateTax>();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(1, 1);
            Assert.Pass();
        }

        /// <summary>
        /// Runs a test that tests Flat Value Tax Calculation that PASSES
        /// </summary>
        [Test]
        public void CalculateFlatValueTaxPass()
        {

            var tax = _calculateTax.CalculateFlatValueTax(100000M);

            Assert.AreEqual(5000M, tax);
            Assert.Pass();
        }

        /// <summary>
        /// Runs a test that tests Flat Value Tax Calculation that FAILS
        /// </summary>
        [Test]
        public void CalculateFlatValueTaxFail()
        {

            var tax = _calculateTax.CalculateFlatValueTax(100000M);

            Assert.AreNotEqual(15000M, tax);
            Assert.Pass();
        }

        /// <summary>
        /// Runs a test that tests Flat Rate Tax Calculation that PASSES
        /// </summary>
        [Test]
        public void CalculateFlatRateTaxPass()
        {

            var tax = _calculateTax.CalculateFlatRateTax(100000M);

            Assert.AreEqual(17500M, tax);
            Assert.Pass();
        }

        /// <summary>
        /// Runs a test that tests Flat Rate Tax Calculation that FAILS
        /// </summary>
        [Test]
        public void CalculateFlatRateTaxFail()
        {

            var tax = _calculateTax.CalculateFlatRateTax(100000M);

            Assert.AreNotEqual(1000M, tax);
            Assert.Pass();
        }


        /// <summary>
        /// Runs a test that tests Progressive Tax Calculation - Income of 0 to 8350 range
        /// </summary>
        [Test]
        public void CalculateProgressiveRateTaxPass_0_to_8350_Range()
        {
            decimal annualIncome = 8350;
            var expected = annualIncome * 0.10M;

            var tax = _calculateTax.CalculateProgressiveTax(annualIncome);

            Assert.AreEqual(expected, tax);
            Assert.Pass();
        }

        /// <summary>
        /// Runs a test that tests Progressive Tax Calculation - Income of 8351 to 33950 range
        /// </summary>
        [Test]
        public void CalculateProgressiveRateTaxPass_8351_to_33950_Range()
        {
            decimal annualIncome = 10000;
            var expected = 8350 * 0.10M;
            expected += (annualIncome - 8350) * 0.15M;

            var tax = _calculateTax.CalculateProgressiveTax(annualIncome);

            Assert.AreEqual(expected, tax);
            Assert.Pass();
        }

        /// <summary>
        /// Runs a test that tests Progressive Tax Calculation - Income of 33951 to 82250 range
        /// </summary>
        [Test]
        public void CalculateProgressiveRateTaxPass_33951_to_82250_Range()
        {
            decimal annualIncome = 33951;
            var expected = 8350 * 0.10M;
            expected += (33950 - 8350) * 0.15M;
            expected += (annualIncome - 33950) * 0.25M;

            var tax = _calculateTax.CalculateProgressiveTax(annualIncome);

            Assert.AreEqual(expected, tax);
            Assert.Pass();
        }

        /// <summary>
        /// Runs a test that tests Progressive Tax Calculation - Income of 82251 to 171550 range
        /// </summary>
        [Test]
        public void CalculateProgressiveRateTaxPass_82251_to_171550_Range()
        {
            decimal annualIncome = 85000;
            var expected = 8350 * 0.10M;
            expected += (33950 - 8350) * 0.15M;
            expected += (82250 - 33950) * 0.25M;
            expected += (annualIncome - 82250) * 0.28M;

            var tax = _calculateTax.CalculateProgressiveTax(annualIncome);

            Assert.AreEqual(expected, tax);
            Assert.Pass();
        }

        /// <summary>
        /// Runs a test that tests Progressive Tax Calculation - Income of 171551 to 372950 range
        /// </summary>
        [Test]
        public void CalculateProgressiveRateTaxPass_171551_to_372950_Range()
        {
            decimal annualIncome = 171551;
            var expected = 8350 * 0.10M;
            expected += (33950 - 8350) * 0.15M;
            expected += (82250 - 33950) * 0.25M;
            expected += (171550 - 82250) * 0.28M;
            expected += (annualIncome - 171550) * 0.33M;

            var tax = _calculateTax.CalculateProgressiveTax(annualIncome);

            Assert.AreEqual(expected, tax);
            Assert.Pass();
        }

        /// <summary>
        /// Runs a test that tests Progressive Tax Calculation - Income of 171551 to 372950 range
        /// </summary>
        [Test]
        public void CalculateProgressiveRateTaxPass_greater_or_equlas_372951_Range()
        {
            decimal annualIncome = 400000;
            var expected = 8350 * 0.10M;
            expected += (33950 - 8350) * 0.15M;
            expected += (82250 - 33950) * 0.25M;
            expected += (171550 - 82250) * 0.28M;
            expected += (372950 - 171550) * 0.33M;
            expected += (annualIncome - 372950) * 0.35M;

            var tax = _calculateTax.CalculateProgressiveTax(annualIncome);

            Assert.AreEqual(expected, tax);
            Assert.Pass();
        }
    }
}