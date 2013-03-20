using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocalApi.Controllers
{

    public class BaseResult
    {
        public string Code
        {
            get;
            set;
        }
        public string Msg
        {
            get;
            set;
        }
    }

    public class CResult : BaseResult
    {
        public string aaa
        {
            get;
            set;

        }
    }
    public class HomeController : ApiController
    {
        //
        // GET: /Home/
        [ActionName("login")]
        public JsonResult Login()
        {
            return CreateJson(new {ReturnCode=1,Msg="OK" });
        }

    }
}
