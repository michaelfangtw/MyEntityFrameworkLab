using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyEntityFrameworkLab.Models.Repository
{
    public class CustomerRespository: EFRepository<Customers>
    {   
        public CustomerRespository(DbContext db):base(db)
        {
            
        }

        //public int Insert(ViewModel.Customers entity)
        //{
        //    Customers customer = new Customers
        //    {
        //        CustomerID = entity.CustomerID,
        //        ContactTitle = entity.ContactTitle,
        //        City = entity.City,
        //        Address = entity.Address,
        //        CompanyName = entity.CompanyName,
        //        ContactName = entity.ContactName,
        //        Country = entity.Country,
        //        Fax = entity.Fax,
        //        Phone = entity.Phone,
        //        PostalCode = entity.PostalCode,
        //        Region = entity.Region

        //    };
        //    if (!dbContext.Customers.Any(x => x.CustomerID == entity.CustomerID))
        //    {
        //        dbContext.Customers.Add(customer);
        //        return dbContext.SaveChanges();
        //    }
        //    else
        //    {
        //        return -1;
        //    }
        //}

        //public ViewModel.Customers Find(params object[] keyValues)
        //{
        //    var sql = "select * from Customer";            
        //    return dbContext.Database.SqlQuery<ViewModel.Customers>(sql, keyValues).FirstOrDefault();
        //}

        //public int Update(ViewModel.Customers entity)
        //{
        //    var customer = dbContext.Customers.Find(entity.CustomerID);
        //    if (customer != null)
        //    {
        //        dbContext.Entry(customer).CurrentValues.SetValues(entity);
        //        try
        //        {
        //            return dbContext.SaveChanges();
        //        }
        //        catch (Exception)
        //        {
        //            return -1;
        //        }


        //    }
        //    else
        //    {
        //        return -1;
        //    }
        //}

        //public int Delete(object id)
        //{
        //    var customer = dbContext.Customers.Find(id);
        //    if (customer != null)
        //    {
        //        dbContext.Customers.Remove(customer);
        //        return dbContext.SaveChanges();
        //    }
        //    return -1;
        //}

        //public int Delete(ViewModel.Customers entity)
        //{
        //    var customer = dbContext.Customers.Find(entity.CustomerID);
        //    if (customer != null)
        //    {
        //        dbContext.Customers.Remove(customer);
        //        return dbContext.SaveChanges();
        //    }
        //    return -1;
        //}


        //private bool disposed = false;
        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            dbContext.Dispose();
        //        }
        //    }
        //    this.disposed = true;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
    }
}