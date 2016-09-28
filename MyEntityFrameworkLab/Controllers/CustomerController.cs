using MyEntityFrameworkLab.Models.Repository;
using MyEntityFrameworkLab.Models.Service;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;
using MyEntityFrameworkLab.Models.ViewModel;

namespace MyEntityFrameworkLab.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerService _customerService;
        private DbContext db = new NORTHWNDEntities();

        public CustomerController()
        {            
            CustomerRespository respository = new CustomerRespository(db);
            _customerService = new CustomerService(respository);    
        }
        // GET: Customer
        public ActionResult Index()
        {
            IEnumerable<Customers> customers = _customerService.SelectAll();
            return View(customers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customers customer)
        {
            if (ModelState.IsValid) { 
                int ra = _customerService.Insert(customer);
                if (ra > 0)
                {

                    var result = new Result(true, string.Format("Create {0},Successfully", customer.CustomerID));
                    TempData["result"] = result;
                }
                else
                {
                    var result = new Result(false, string.Format("Create {0},Failed", customer.CustomerID));
                    TempData["result"] = result;
                }
                return RedirectToAction("Index");
            }else
            {
                return View(customer);
            }
        }


        public ActionResult Edit(string id)
        {
            Customers customer = _customerService.SelectByID(id);
            if (customer == null)
            {                         
                return RedirectToAction("Index");
            }
            else
            {
                return View(customer);
            }
        }

        [HttpPost]
        public ActionResult Edit(Customers customer)
        {
            if (ModelState.IsValid) // Is User Input Valid?
            { 
                int ra=_customerService.Update(customer);
                if (ra > 0)
                {

                    var result = new Result(true, string.Format("Update {0},Successfully",customer.CustomerID));
                    TempData["result"] = result;
                }
                else
                {
                    var result = new Result(false, string.Format("Update {0},Failed", customer.CustomerID));
                    TempData["result"] = result;
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(string id)
        {            
            Customers customer = _customerService.SelectByID(id);
            return View(customer);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            Customers customer = _customerService.SelectByID(id);
            return View(customer);
        }

        [HttpGet]
        public ActionResult DeleteConfirm(string id)
        {
            int ra = _customerService.Delete(id);            
            if (ra > 0) {

                var result = new Result(true, string.Format("Delete {0},Successfully", id));
                TempData["result"] = result;
            }
            else
            {
                var result = new Result(false, string.Format("Delete {0},Failed", id));
                TempData["result"] = result;
            }
            return RedirectToAction("Index");
        }
    }
}