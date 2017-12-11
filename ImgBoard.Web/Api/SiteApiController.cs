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

        [HttpGet]
        [Route("siteapi/getimagesbycategory/{id}")]
        public async Task<IEnumerable<Image>> GetImagesByCategory(int id)
        {
            return await Images.GetAsync(categoryId:id);
        }

        [HttpGet]
        [Route("siteapi/getmatchingcategories/{term}")]
        public async Task<IEnumerable<Category>> GetMatchingCategories(string term)
        {
            return await Categories.GetMatchAsync(term);
        }
    }
}
