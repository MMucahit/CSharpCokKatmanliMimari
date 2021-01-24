using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Northwind.Core.DataAccess.NHihabernate;
using Framework.Northwind.DataAccess.Abstract;
using Framework.Northwind.Entities.ComplexTypes;
using Framework.Northwind.Entities.Concrete;

namespace Framework.Northwind.DataAccess.Concrete.NHibernate
{
    public class NhProductDal:NhEntityRepositoryBase<Product>,IProductDal
    {
        private NHihaberbateHelper _nHihaberbateHelper;
        public NhProductDal(NHihaberbateHelper nHihaberbateHelper) : base(nHihaberbateHelper)
        {
            _nHihaberbateHelper = nHihaberbateHelper;
        }

        public List<ProductDetail> GetProductDetails()
        {
            using (var session = _nHihaberbateHelper.OpenSession())
            {
                var result = from p in session.Query<Product>()
                    join c in session.Query<Category>() on p.CategoryId equals c.CategoryId
                    select new ProductDetail
                    {
                        ProductId = p.ProductId,
                        CategoryName = c.CategoryName,
                        ProductName = p.ProductName
                    };
                return result.ToList();
            }
        }
    }
}
