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
    public class BooksRepositoryTests
    {

        [TestMethod()]
        public void GetArgumentException()
        {
            BooksRepository Library = new BooksRepository();
            Assert.ThrowsException<ArgumentException>(()=>Library.Get(orderby:"a"));
            
        }

        [TestMethod()]
        public void GetPriceFilterTest()
        {
            BooksRepository Library = new BooksRepository();
            List<Book> LibraryFiltered = Library.Get(250);

            Assert.AreEqual(Library.Get()[1], LibraryFiltered[0]);
            Assert.AreNotEqual(Library.Get()[1], LibraryFiltered[1]); 
        }

        [TestMethod()]
        public void GetFilterPriceAscTest()
        {
            BooksRepository Library = new BooksRepository();
            List<Book> PricedLibrary = Library.Get(orderby: "Price");
            Assert.AreNotEqual(Library.Get()[0],PricedLibrary[0]);
            Assert.AreEqual(Library.Get()[2],PricedLibrary[4]);
            Assert.AreEqual(Library.Get()[3], PricedLibrary[0]);
        }

        [TestMethod()]
        public void GetFilterPriceDescTest()
        {
            BooksRepository Library = new BooksRepository();
            List<Book> PricedLibrary = Library.Get(orderby: "PriceDesc");
            Assert.AreNotEqual(Library.Get()[0], PricedLibrary[0]);
            Assert.AreEqual(Library.Get()[3], PricedLibrary[4]);
            Assert.AreEqual(Library.Get()[2], PricedLibrary[0]);
        }

        [TestMethod()]
        public void GetFilterTitleAscTest()
        {
            BooksRepository Library = new BooksRepository();
            List<Book> NameLibrary = Library.Get(orderby: "Name");
            Assert.AreNotEqual(Library.Get()[0], NameLibrary[0]);
            Assert.AreEqual(Library.Get()[3], NameLibrary[0]);
            Assert.AreEqual(Library.Get()[0], NameLibrary[4]);
        }

        [TestMethod()]
        public void GetFilterTitleDescTest()
        {
            BooksRepository Library = new BooksRepository();
            List<Book> NameLibrary = Library.Get(orderby: "NameDesc");
            Assert.AreNotEqual(Library.Get()[1], NameLibrary[1]);
        }

        [TestMethod()]
        public void GetByIDTest()
        {
            BooksRepository Library= new BooksRepository();
            Assert.AreEqual(Library.Get()[1], Library.GetByID(2));
        }

        [TestMethod()]
        public void AddTest()
        {
            BooksRepository Library = new BooksRepository();
            Book NewBook = new Book { Id = 4, Price = 400, Title = "bålets blå ild" };
            Assert.AreEqual(NewBook, Library.Add(NewBook));
        }

        [TestMethod()]
        public void DeleteTest()
        {
            BooksRepository Library = new BooksRepository();
            Assert.AreEqual(Library.GetByID(3), Library.Delete(3));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            BooksRepository Library = new BooksRepository();
            Book NewBook = new Book { Id = 4, Price = 400, Title = "bålets blå ild" };
            Assert.AreEqual(Library.Update(4, NewBook),Library.GetByID(4));
        }

        [TestMethod()]
        public void DeleteTestNull()
        {
            BooksRepository Library = new BooksRepository();
            Assert.IsNull(Library.Delete(10));
        }

        [TestMethod()]
        public void GetByIDTestNull()
        {
            BooksRepository Library = new BooksRepository();
            Assert.IsNull(Library.GetByID(10));
        }

        [TestMethod()]
        public void UpdateTestNull()
        {
            BooksRepository Library = new BooksRepository();
            Book NewBook = new Book { Id = 4, Price = 400, Title = "bålets blå ild" };
            Assert.IsNull(Library.Update(10, NewBook));
        }
    }
}