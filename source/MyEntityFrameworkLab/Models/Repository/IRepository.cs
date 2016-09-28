using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//DataAccessLayer
namespace MyEntityFrameworkLab.Models.Repository
{
    public interface IRepository<TEntity> :IDisposable
    where TEntity : class 
    {        
        //Create
        int Insert(TEntity entity);
        //Read
        List<TEntity> Select(object keyValues);
        List<TEntity> SelectAll();
        //Update
        int Update(TEntity entity);
        //Delete        
        int Delete(object id);
        int Delete(TEntity entity);
    }
}
