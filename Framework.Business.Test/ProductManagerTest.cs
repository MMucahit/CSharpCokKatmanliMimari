using System;
using FluentValidation;
using Framework.Northwind.Business.Concrete.Manager;
using Framework.Northwind.DataAccess.Abstract;
using Framework.Northwind.Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Framework.Business.Test
{
    [TestClass]
    public class ProductManagerTest
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void ProductValidationCheck()
        {
            Mock<IProductDal> mock = new Mock<IProductDal>();
            ProductManager productManager = new ProductManager(mock.Object);

            productManager.Add(new Product
            {
                
            }); 
        }
    }
}
