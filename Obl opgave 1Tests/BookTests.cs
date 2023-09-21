using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obl_opgave_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obl_opgave_1.Tests
{
    [TestClass()]
    public class BookTests
    {

        [TestMethod()]
        public void ValidateTitleTestExceptionNull()
        {
            Book booknull = new Book() { Id = 1, Title =null, Price = 600 };
            Assert.ThrowsException<ArgumentNullException>(()=>booknull.ValidateTitle());
        }

        [TestMethod()]
        public void ValidateTitleTestExceptionOutOfRange()
        {
            Book booktitle4 = new Book() { Id = 1, Title ="ø", Price = 600 };
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=>booktitle4.ValidateTitle());
        }

        [TestMethod()]
        public void ValidatePriceTestException()
        {
            Book bookPriceHigh = new Book() { Id = 1, Title = "Den forkerte død", Price = 1200 };
            Book bookNoPrice = new Book() { Id = 2, Title = "Den forkerte død", Price = -1 };
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=>bookPriceHigh.ValidatePrice());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookNoPrice.ValidatePrice());

        }

        [TestMethod()]
        public void ToStringTest()
        {
            Book BookPrint = new Book() { Id = 1, Title = "Den forkerte død", Price = 250 };
            Assert.AreEqual($" Id: {BookPrint.Id} Title: {BookPrint.Title} Price: {BookPrint.Price}", BookPrint.ToString());
        }
    }
}