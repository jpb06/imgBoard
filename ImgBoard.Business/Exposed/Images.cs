using ImgBoard.Business.Internal.Persistence.Contracts;
using ImgBoard.Business.InversionOfControl;
using ImgBoard.Dal.Models.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using ImgBoard.Models.Main;

namespace ImgBoard.Business.Exposed
{
    public static class Images
    {
        public static async Task<List<Image>> GetAsync(
            int[] tagsIds = null, 
            int[] categoriesIds = null,
            string name = null,
            string description = null,
            string uploader = null,
            string extension = null)
        {
            using (IUnityContainer unit = IoCConfiguration.container.CreateChildContainer())
            {
                IImagesManager manager = unit.Resolve<IImagesManager>();

                List<Image> images = await manager.FetchImagesAsync(
                    tagsIds, categoriesIds, name, description, uploader, extension
                );

                return images;
            }
        }
    }
}
