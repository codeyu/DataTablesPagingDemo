using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataTablesPagingDemo.Helper;
namespace DataTablesPagingDemo.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductRepository _repository = new ProductRepository();
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult GetProduct(DataTablesSent sent)
        {
            var petaPocoPage = _repository.GetCustomers(sent);
            var pageResponse = DataTablesReturned.PageResponse(sent, petaPocoPage);
            return Json(pageResponse);
        }
        
    }
}