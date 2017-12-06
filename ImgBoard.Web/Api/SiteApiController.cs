using System.Collections.Generic;
using System.Web.Http;
using ImgBoard.Models.Main;
using ImgBoard.Business.Exposed;
using System.Threading.Tasks;

namespace ImgBoard.Web.Api
{
    public class SiteApiController : ApiController
    {
        [HttpGet]
        [Route("siteapi/getimages")]
        public async Task<IEnumerable<Image>> GetImages()
        {
            return await Images.GetAsync();
        }

        [HttpGet]
        [Route("siteapi/getimagesmatchingcategory/{term}")]
        public async Task<IEnumerable<Image>> GetImagesMatchingCategory(string term)
        {
            return await Images.GetMatchAsync(term);
        }
    }
}
