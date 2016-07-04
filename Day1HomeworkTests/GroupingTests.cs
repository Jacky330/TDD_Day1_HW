using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day1Homework;
using System.Collections.Generic;
using ExpectedObjects;
using FluentAssertions;
using System;

namespace Day1Homework.Tests
{
    [TestClass()]
    public class GroupingTests
    {

        private IList<Product> GetProducts() {
            return new List<Product>() {
                new Product {Id=1,Cost=1,Revenue=11,SellPrice=21 },
                new Product {Id=2,Cost=2,Revenue=12,SellPrice=22 },
                new Product {Id=3,Cost=3,Revenue=13,SellPrice=23 },
                new Product {Id=4,Cost=4,Revenue=14,SellPrice=24 },
                new Product {Id=5,Cost=5,Revenue=15,SellPrice=25 },
                new Product {Id=6,Cost=6,Revenue=16,SellPrice=26 },
                new Product {Id=7,Cost=7,Revenue=17,SellPrice=27 },
                new Product {Id=8,Cost=8,Revenue=18,SellPrice=28 },
                new Product {Id=9,Cost=9,Revenue=19,SellPrice=29 },
                new Product {Id=10,Cost=10,Revenue=20,SellPrice=30 },
                new Product {Id=11,Cost=11,Revenue=21,SellPrice=31 }
            };
        }
        private class Product
        {
            public int Id { get; set; }
            public int Cost { get; set; }
            public int Revenue { get; set; }
            public int SellPrice { get; set; }
        }

        #region TestMethods
        [TestMethod()]
        public void TestForSubtotal_3筆一組_取Cost總和_結果應為6_15_24_21()
        {
            // arrange
            var g = new Grouping<Product>(GetProducts());
            var size = 3;
            var colName = "Cost";            

            // atc
            var actual = g.Subtotal(size, colName);

            // assert
            var expected = new decimal[] { 6, 15, 24, 21 };

            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod()]
        public void TestForSubtotal_4筆一組_取Revenue總和_結果應為50_66_60()
        {
            // arrange
            var g = new Grouping<Product>(GetProducts());
            var size = 4;
            var colName = "Revenue";

            // atc
            var actual = g.Subtotal(size, colName);

            // assert
            var expected = new decimal[] { 50, 66, 60 };
            expected.ToExpectedObject().ShouldEqual(actual);
        }
        [TestMethod()]
        public void TestForSubtotal_分組數量設為0_結果應擲回ArgumentException() {
            // arrange
            var g = new Grouping<Product>(GetProducts());
            var size = 0;
            var colName = "Revenue";

            // act
            Action act = () => g.Subtotal(size, colName);

            // assert
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod()]
        public void TestForSubtotal_分組數量設為1_屬性名稱設為Empty_結果應擲回ArgumentException()
        {
            // arrange
            var g = new Grouping<Product>(GetProducts());
            var size = 1;
            var colName = string.Empty;

            // act
            Action act = () => g.Subtotal(size, colName);

            // assert
            act.ShouldThrow<ArgumentException>();
        }
        #endregion
    }   
}
