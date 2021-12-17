using BestTestsExample;
using Moq;
using NUnit.Framework;
using System;

namespace BestTestsExampleTests
{
    [TestFixture]
    internal class PriceCalculatorTests
    {
        //[Test]
        //public void GetDiscountedPrice_NotTuesday_ReturnsFullPrice()
        //{
        //    var priceCalculator = new PriceCalculator();

        //    var actual = priceCalculator.GetDiscountedPrice(2);

        //    Assert.AreEqual(2, actual);
        //}

        //[Test]
        //public void GetDiscountedPrice_OnTuesday_ReturnsHalfPrice()
        //{
        //    var priceCalculator = new PriceCalculator();

        //    var actual = priceCalculator.GetDiscountedPrice(2);

        //    Assert.AreEqual(1, actual);
        //}

        [Test]
        public void GetDiscountedPrice_NotTuesday_ReturnsFullPrice()
        {
            var priceCalculator = new PriceCalculator();
            var dateTimeProviderStub = new Mock<IDateTimeProvider>();
            dateTimeProviderStub.Setup(dtp => dtp.DayOfWeek()).Returns(DayOfWeek.Monday);

            var actual = priceCalculator.GetDiscountedPrice(2, dateTimeProviderStub.Object);

            Assert.AreEqual(2, actual);
        }

        [Test]
        public void GetDiscountedPrice_OnTuesday_ReturnsHalfPrice()
        {
            var priceCalculator = new PriceCalculator();
            var dateTimeProviderStub = new Mock<IDateTimeProvider>();
            dateTimeProviderStub.Setup(dtp => dtp.DayOfWeek()).Returns(DayOfWeek.Tuesday);

            var actual = priceCalculator.GetDiscountedPrice(2, dateTimeProviderStub.Object);

            Assert.AreEqual(1, actual);
        }
    }
}