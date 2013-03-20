using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocalApi.Controllers
{
    
    public class ApiController : Controller
    {
        [NonAction]
        public JsonResult CreateJson(object data)
        {
            JsonResult json = new JsonResult
            {
                JsonRequestBehavior=JsonRequestBehavior.AllowGet,
                Data = data
            };
            return json;
        }


    }
}
