using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Northwind.Core.DataAccess;
using Framework.Northwind.Entities.ComplexTypes;
using Framework.Northwind.Entities.Concrete;

namespace Framework.Northwind.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetail> GetProductDetails();
    }
}
