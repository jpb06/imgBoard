using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImgBoard.Web.Controllers
{
    public class ImagesController : Controller
    {
        // GET: Images
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ByCategory()
        {
            return View();
        }

        public ActionResult ByTag()
        {
            return View();
        }
    }
}