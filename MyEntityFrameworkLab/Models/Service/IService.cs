using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//BusinessLogicLayer
namespace MyEntityFrameworkLab.Models.Service
{
    public interface IService<TEntity> where TEntity :class
    {
        int Insert(TEntity entity);
        int Update(TEntity entity);
        int Delete(object id);
        int Delete(TEntity entity);
        List<TEntity> Select(object keyValues);
        List<TEntity> SelectAll();
        List<TEntity> SelectPage(int page, int pageSize, out int totalCount, object keyValues);
    }
}