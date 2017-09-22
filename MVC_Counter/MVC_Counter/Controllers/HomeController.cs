using MVC_Counter.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Counter.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICounterDAL _iCounter = null;
        public HomeController(ICounterDAL iCounter)
        {
            this._iCounter = iCounter;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var number = _iCounter.GetCurrentValue();
            ViewBag.counterNumber = number.CounterNumber;
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost()
        {
            var number = _iCounter.Increase();
            ViewBag.counterNumber = number;
            return View();
        }
    }
}