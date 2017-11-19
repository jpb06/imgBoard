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
    public class ImagesController : Controller
    {
        // GET: Images
        public async Task<ActionResult> Index()
        {
            var images = await Images.GetAsync();

            return View(images);
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