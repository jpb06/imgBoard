using ImgBoard.Business.Exposed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ImgBoard.Models.Main;
using ImgBoard.Web.ViewModels;

namespace ImgBoard.Web.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Results(SearchViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ByCategory(string query)
        {
            List<Image> images = null;

            if (!string.IsNullOrEmpty(query))
                images = await Images.GetMatchAsync(query);
            
            return View("Results", new SearchViewModel { Term = query, Results = images });
        }
    }
}