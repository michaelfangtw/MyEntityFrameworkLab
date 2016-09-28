using MyEntityFrameworkLab.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEntityFrameworkLab.Models.Service
{
    public abstract class Service<TEntity> :IService<TEntity>
    where TEntity : class 
    {
        //dal
        private readonly IRepository<TEntity> _repository;
        protected Service(IRepository<TEntity> repository)            
        {            
            _repository = repository;
        }

        public virtual int Insert(TEntity entity) { return _repository.Insert(entity); }

        public virtual int Update(TEntity entity) {return _repository.Update(entity); }

        public virtual int Delete(object id) { return _repository.Delete(id); }

        public virtual int Delete(TEntity entity) { return _repository.Delete(entity); }



        public virtual List<TEntity> SelectAll()
        {
            return _repository.SelectAll();
        }
        public List<TEntity> Select(object keyValues)
        {
            return _repository.Select(keyValues);
        }
        abstract public List<TEntity> SelectPage(int page, int pageSize, out int totalCount, object keyValues);

    }
}