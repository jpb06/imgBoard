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
        public async Task<ActionResult> Index()
        {
            var images = await Images.GetAsync();

            return View(images);
        }

        public async Task<ActionResult> ByCategory(int id)
        {
            var images = await Images.GetAsync(categoryId:id);

            return View(images);
        }

        public async Task<ActionResult> ByTag(int id)
        {
            var images = await Images.GetAsync(new int[] { id });

            return View(images);
        }
    }
}