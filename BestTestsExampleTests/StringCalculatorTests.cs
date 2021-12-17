using BestTestsExample;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BestTestsExampleTests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private StringCalculator _stringCalculator;
        [SetUp]
        [OneTimeSetUp]
        public void Setup()
        {
            _stringCalculator = new StringCalculator();
        }

        #region Naming
        //Плохо
        [Test]
        public void Test_Single()
        {
            var stringCalculator = new StringCalculator();

            var actual = stringCalculator.Add("0");

            Assert.AreEqual(0, actual);
        }

        //Лучше
        [Test]
        public void Add_SingleNumber_ReturnsSameNumber()
        {
            var stringCalculator = new StringCalculator();

            var actual = stringCalculator.Add("0");

            Assert.AreEqual(0, actual);
        }
        #endregion

        #region Order
        //Плохо
        //[Test]
        //public void Add_EmptyString_ReturnsZero()
        //{
        //    // Arrange
        //    var stringCalculator = new StringCalculator();

        //    // Assert
        //    Assert.AreEqual(0, stringCalculator.Add(""));
        //}

        //Лучше
        [Test]
        public void Add_EmptyString_ReturnsZero()
        {
            // Arrange
            var stringCalculator = new StringCalculator();

            // Act
            var actual = stringCalculator.Add("");

            // Assert
            Assert.AreEqual(0, actual);
        }
        #endregion

        #region Minimalizm

        ////Плохо
        //[Test]
        //public void Add_SingleNumber_ReturnsSameNumber()
        //{
        //    var stringCalculator = new StringCalculator();

        //    var actual = stringCalculator.Add("42");

        //    Assert.AreEqual(42, actual);
        //}

        //Лучше
        [Test]
        public void Add_SingleNumber_ReturnsSameNumber1()
        {
            var stringCalculator = new StringCalculator();

            var actual = stringCalculator.Add("0");

            Assert.AreEqual(0, actual);
        }
        #endregion

        #region NoMagic
        //Плохо
        [Test]
        public void Add_BigNumber_ThrowsException()
        {
            var stringCalculator = new StringCalculator();

            TestDelegate actual = () => stringCalculator.Add("1001");

            Assert.Throws<OverflowException>(actual);
        }

        //Лучше
        [Test]
        public void Add_MaximumSumResult_ThrowsOverflowException()
        {
            var stringCalculator = new StringCalculator();
            const string MAXIMUM_RESULT = "1001";

            TestDelegate actual = () => stringCalculator.Add(MAXIMUM_RESULT);

            Assert.Throws<OverflowException>(actual);
        }
        #endregion

        #region NoLogic
        //Плохо
        [Test]
        public void Add_MultipleNumbers_ReturnsCorrectResultsWithLogic()
        {
            var stringCalculator = new StringCalculator();
            var testCases = new Dictionary<string, int>
            {
                { "0", 0 },
                { "1", 1 },
                { "2", 3 }
            };

            foreach (var test in testCases)
            {
                Assert.AreEqual(test.Value, stringCalculator.Add(test.Key));
            }
        }

        //Лучше
        [Test]
        [TestCase("0", 0)]
        [TestCase("1", 1)]
        [TestCase("2", 2)]
        public void Add_MultipleNumbers_ReturnsCorrectResults(string input, int expected)
        {
            var stringCalculator = new StringCalculator();

            var actual = stringCalculator.Add(input);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region SingleAction
        //Плохо
        [Test]
        public void Add_EmptyEntries_ShouldBeTreatedAsZero()
        {
            // Act
            var actual1 = _stringCalculator.Add("");
            var actual2 = _stringCalculator.Add(",");

            // Assert
            Assert.AreEqual(1, actual1);
            Assert.AreEqual(0, actual2);
        }

        //Лучше
        [Test]
        [TestCase("", 0)]
        [TestCase(",", 1)]
        public void Add_EmptyEntries_ShouldBeTreatedAsZero(string input, int expected)
        {
            // Arrange
            var stringCalculator = new StringCalculator();

            // Act
            var actual = stringCalculator.Add(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion
    }
}