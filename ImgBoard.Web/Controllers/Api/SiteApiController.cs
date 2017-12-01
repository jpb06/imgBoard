using System.Collections.Generic;
using System.Web.Http;
using ImgBoard.Models.Main;
using ImgBoard.Business.Exposed;
using System.Threading.Tasks;

namespace ImgBoard.Web.Controllers.Api
{
    public class SiteApiController : ApiController
    {
        [HttpGet]
        [Route("siteapi/imagesmatchingcategory/{term}")]
        public async Task<IEnumerable<Image>> ImagesMatchingCategory(string term)
        {
            return await Images.GetMatchAsync(term);
        }

        //public IHttpActionResult GetProduct(int id)
        //{
        //    var product = products.FirstOrDefault((p) => p.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(product);
        //}
    }
}
