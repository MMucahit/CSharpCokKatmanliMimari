using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Northwind.Core.Entities;

namespace Framework.Northwind.Core.DataAccess.NHihabernate
{
    public class NhQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private NHihaberbateHelper _nHihaberbateHelper;
        private IQueryable<T> _entities;
        public NhQueryableRepository(NHihaberbateHelper nHihaberbateHelper)
        {
            _nHihaberbateHelper = nHihaberbateHelper;
        }

        public IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        public virtual IQueryable<T> Entities
        {
            get
            {
                if (_entities == null )
                {
                    _entities = _nHihaberbateHelper.OpenSession().Query<T>();
                }

                return _entities;
            }
        }
    }
}
