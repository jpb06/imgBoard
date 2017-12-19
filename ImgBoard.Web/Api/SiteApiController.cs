using System.Collections.Generic;
using System.Web.Http;
using ImgBoard.Models.Main;
using ImgBoard.Business.Exposed;
using System.Threading.Tasks;
using ImgBoard.Models.Api;

namespace ImgBoard.Web.Api
{
    public class SiteApiController : ApiController
    {
        [HttpGet]
        [Route("siteapi/getallimages")]
        public async Task<IEnumerable<Image>> GetAllImages()
        {
            return await Images.GetAsync();
        }

        [HttpPost]
        [Route("siteapi/getimages")]
        public async Task<IEnumerable<Image>> GetImages(GetImagesParameters parameters)
        {
            return await Images.GetAsync(
                parameters.TagsIds, 
                parameters.CategoriesIds, 
                parameters.Name, 
                parameters.Description, 
                parameters.Uploader, 
                parameters.Extension);
        }

        [HttpGet]
        [Route("siteapi/getmatchingcategories/{term}")]
        public async Task<IEnumerable<Category>> GetMatchingCategories(string term)
        {
            return await Categories.GetMatchAsync(term);
        }
    }
}
