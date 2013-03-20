using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocalApi.Controllers
{
    public class TestConnectionController : ApiController
    {
        //
        // GET: /TestConnection/

        public JsonResult Index()
        {
            return CreateJson(new { Message = "ssss", Data = new CResult() });
        }

    }
}
