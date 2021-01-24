using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Framework.Northwind.Core.Entities;

namespace Framework.Northwind.Core.DataAccess.NHihabernate
{
    public class NhEntityRepositoryBase<TEntity>:IEntityRepository<TEntity>
    where TEntity:class,IEntity,new()
    {
        private NHihaberbateHelper _nHihaberbateHelper;

        public NhEntityRepositoryBase(NHihaberbateHelper nHihaberbateHelper)
        {
            _nHihaberbateHelper = nHihaberbateHelper;
        }

        public TEntity Add(TEntity entity)
        {
            using (var sesion = _nHihaberbateHelper.OpenSession())
            {
                sesion.Save(entity);
                return entity;
            }
        }

        public void Delete(TEntity entity)
        {
            using (var sesion = _nHihaberbateHelper.OpenSession())
            {
                sesion.Delete(entity);
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var sesion = _nHihaberbateHelper.OpenSession())
            {
                return sesion.Query<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var sesion = _nHihaberbateHelper.OpenSession())
            {
                return filter == null
                    ? sesion.Query<TEntity>().ToList()
                    : sesion.Query<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var sesion = _nHihaberbateHelper.OpenSession())
            {
                sesion.Update(entity);
                return entity;
            }
        }
    }
}
