using ImgBoard.Business.Exposed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ImgBoard.Models.Main;

namespace ImgBoard.Web.Controllers
{
    public class BoardController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}