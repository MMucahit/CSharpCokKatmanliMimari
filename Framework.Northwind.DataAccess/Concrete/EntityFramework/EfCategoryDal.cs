using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Northwind.Core.DataAccess.EntityFramework;
using Framework.Northwind.DataAccess.Abstract;
using Framework.Northwind.Entities.Concrete;

namespace Framework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal: EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {

    }
}
