using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ascentic.WorkFlow.MVCClient.Controllers
{
    public class ExceptionController : Controller
    {
        // GET: Exception
        public ActionResult Index()
        {
            ViewBag.ExceptionText = TempData["ExceptionText"].ToString();
            return View();
        }
    }
}