using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using DataTablesPagingDemo.Helper;
namespace DataTablesPagingDemo.MVC
{
    public class DataTablesModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string json = controllerContext.HttpContext.Request["data"];
            return JsonConvert.DeserializeObject<DataTablesSent>(json);
        }
    }
}