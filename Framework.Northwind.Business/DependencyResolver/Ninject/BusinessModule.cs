using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Northwind.Business.Abstract;
using Framework.Northwind.Business.Concrete.Manager;
using Framework.Northwind.Core.DataAccess;
using Framework.Northwind.Core.DataAccess.EntityFramework;
using Framework.Northwind.Core.DataAccess.NHihabernate;
using Framework.Northwind.DataAccess.Abstract;
using Framework.Northwind.DataAccess.Concrete.EntityFramework;
using Framework.Northwind.DataAccess.Concrete.NHibernate;
using Ninject.Modules;

namespace Framework.Northwind.Business.DependencyResolver.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>();


            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepositoryBase<>));
            Bind<DbContext>().To<NorthwindContext>();
            Bind<NHihaberbateHelper>().To<SqlServerHelper>();
        }
    }
}
