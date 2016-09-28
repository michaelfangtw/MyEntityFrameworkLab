using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MyEntityFrameworkLab.Models.Repository
{
    public class EFRepository<TEntity> : IRepository<TEntity>, IDisposable
    where TEntity : class
    {
        protected DbContext _context;
        private DbSet<TEntity> _dbSet;
        public EFRepository(DbContext db)
        {
            this._context = db;
            if (_context != null)
            {
                _dbSet = _context.Set<TEntity>();
            }
        }
        public int Insert(TEntity entity)
        {
            int ra = 0;
            try
            {
                _dbSet.Add(entity);
                ra=_context.SaveChanges();
            }catch
            {
                ra=-1;
            }
            return ra;
        }

        /// <summary>
        /// 查詢TEntity new {customerID='1',status=1}   
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public List<TEntity> Select(object keyValues=null)
        {
            string sql = string.Format("select * from {0}", typeof(TEntity).Name);
            int count = 0;
            SqlParameter[] paramArray = null;
            if (keyValues != null)
            {
                int size=keyValues.GetType().GetProperties().Length;
                 paramArray = new SqlParameter[size];
            
                sql += " where ";
                foreach (PropertyInfo p in keyValues.GetType().GetProperties())
                {
                    if (count != 0) sql += " and ";
                    sql += string.Format(" {0}=@p{1} ", p.Name,count);
                    paramArray[count]=new SqlParameter(string.Format("@p{0}",count), p.GetValue(keyValues));                   
                   count++;
                }
            }
            if (paramArray != null)
            {
                return _dbSet.SqlQuery(sql, paramArray).ToList();
            }else
            {
                return _dbSet.SqlQuery(sql).ToList();
            }
        }

        public List<TEntity> SelectAll()
        {
            return Select();
        }

        public int Update(TEntity entity)
        {
            if (entity != null) { 
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
            return _context.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
            return _context.SaveChanges();
        }

        public int Delete(object id)
        {
            var entity = _dbSet.Find(id);            
            return Delete(entity);
        }



        //disposed 
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}