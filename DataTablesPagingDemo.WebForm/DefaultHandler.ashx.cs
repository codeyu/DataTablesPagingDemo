using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using DataTablesPagingDemo.Helper;
namespace DataTablesPagingDemo.WebForm
{
    /// <summary>
    /// DefaultHandler 的摘要说明
    /// </summary>
    public class DefaultHandler : IHttpHandler
    {
        private readonly ProductRepository _repository = new ProductRepository();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string json = context.Request["data"];//or：context.Request.Form[0]
            var datatable = JsonConvert.DeserializeObject<DataTablesSent>(json);
            context.Response.Write(GetProduct(datatable));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public string GetProduct(DataTablesSent sent)
        {
            var petaPocoPage = _repository.GetCustomers(sent);
            var pageResponse = DataTablesReturned.PageResponse(sent, petaPocoPage);
            string json = JsonConvert.SerializeObject(pageResponse);
            return json;
        }
    }
}