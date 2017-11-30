using ImgBoard.Business.Internal.Persistence.Contracts;
using ImgBoard.Business.InversionOfControl;
using ImgBoard.Dal.Models.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using ImgBoard.Business.Internal.Model;
using ImgBoard.Models.Main;

namespace ImgBoard.Business.Exposed
{
    public static class Images
    {
        public static async Task<List<Image>> GetAsync(int[] tagsIds = null, int? categoryId = null)
        {
            using (IUnityContainer unit = IoCConfiguration.container.CreateChildContainer())
            {
                IImagesManager manager = unit.Resolve<IImagesManager>();
                
                IEnumerable<DbImage> images = null;

                if (tagsIds != null)
                {
                    images = await manager.FetchTaggedImagesAsync(tagsIds);

                    if(categoryId.HasValue)
                        images = images.Where(i => i.IdCategory == categoryId);
                }
                else if (categoryId.HasValue)
                {
                    images = await manager.FetchImagesByCategoryAsync(categoryId.Value);
                }
                else
                {
                    images = await manager.FetchImagesAsync();
                }

                return images.Select(el => el.ToExposed())
                             .ToList();
            }
        }

        public static async Task<List<Image>> GetMatchAsync(string term)
        {
            using (IUnityContainer unit = IoCConfiguration.container.CreateChildContainer())
            {
                IImagesManager manager = unit.Resolve<IImagesManager>();

                IEnumerable<DbImage> images = await manager.FetchImagesMatchingCategory(term);
                
                return images.Select(el => el.ToExposed())
                             .ToList();
            }
        }
    }
}
