using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyEntityFrameworkLab.Models.Repository;
using System.Data.Entity.Core.Objects;

namespace MyEntityFrameworkLab.Models.Service
{
    public class CustomerService : Service<Customers>
    {
        private readonly CustomerRespository _repository;

        public CustomerService(CustomerRespository repository) :base(repository)
        {
            this._repository = repository;
        }

        public override List<Customers> SelectAll()
        {
            List<Customers> list = _repository.SelectAll();
            return list;
        }


        public Customers SelectByID(string customerID)  
        {
            var param = new {
                CustomerID = customerID
            };
            return Select(param).FirstOrDefault();
        }        

        public override List<Customers> SelectPage(int page, int pageSize, out int totalCount, object keyValues)
        {
            throw new NotImplementedException();
        }
    }
}