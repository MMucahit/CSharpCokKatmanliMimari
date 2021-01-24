using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Northwind.Business.Abstract;
using Framework.Northwind.Business.ValidationRules.FluentValidation;
using Framework.Northwind.Core.Aspect.PostSharp;
using Framework.Northwind.Core.Aspect.PostSharp.TransactionAspects;
using Framework.Northwind.Core.Aspect.PostSharp.ValidationAspects;
using Framework.Northwind.Core.CrossCuttingConcerns.Caching.Microsoft;
using Framework.Northwind.DataAccess.Abstract;
using Framework.Northwind.Entities.Concrete;
using Framework.Northwind.Core.Aspect.PostSharp.CacheAspects;
using Framework.Northwind.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Framework.Northwind.Core.LogAspects;

namespace Framework.Northwind.Business.Concrete.Manager
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheAspect(typeof(MemoryCacheManager),120)]
        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        [TrasnactionScopeAspects]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            //Business Code
            _productDal.Update(product2);
        }
    }
}
