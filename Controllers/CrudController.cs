using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AllergyApp.Controllers
{
    public abstract class CrudController<T> : ApiController where T : class
    {
        private readonly DbSet<T> _entities;
        private readonly AllergyAppDb _context;
        private readonly Func<int, Expression<Func<T, bool>>> _idComparatorFactory;
        private readonly Action<T, T> _dataUpdater;

        protected CrudController ( Func<AllergyAppDb, DbSet<T>> entityGetter, Func<int, Expression<Func<T, bool>>> idComparatorFactory, Action<T, T> dataUpdater)
        {
            _context = new AllergyAppDb();
            _entities = entityGetter(_context);
            _idComparatorFactory = idComparatorFactory;
            _dataUpdater = dataUpdater;
        }


        public IHttpActionResult Get()
        {
            return Ok(_entities.ToList());
        }

        public IHttpActionResult Get(int id)
        {
            var entity = _entities.SingleOrDefault(_idComparatorFactory(id));
            if ( entity == default)
            {
                return BadRequest("No entity matching the provided id was found");
            }
            return Ok(entity);
        }

        public IHttpActionResult Post(T entity)
        {
            entity = _entities.Add(entity);
            _context.SaveChanges();
            return Ok(entity);
        }

        public IHttpActionResult Put(int id, T entity)
        {
            var oldEntity = _entities.SingleOrDefault(_idComparatorFactory(id));
            if (oldEntity == null)
            {
                return BadRequest("No entity matching the provided id was found");
            }
            _dataUpdater(oldEntity, entity);
            _context.SaveChanges();
            return Ok(oldEntity);
        }

        public IHttpActionResult Delete(int id)
        {
            var entity = _entities.FirstOrDefault(_idComparatorFactory(id));
            if ( entity == default)
            {
                return BadRequest("No entity matching the provided id was found");
            }
            entity = _entities.Remove(entity);
            _context.SaveChanges();
            return Ok(entity);
        }

    }
}
