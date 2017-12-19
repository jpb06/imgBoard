using ImgBoard.Business.Internal.Persistence.Contracts;
using ImgBoard.Business.InversionOfControl;
using ImgBoard.Models.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ImgBoard.Business.Exposed
{
    public static class Tags
    {
        public static async Task<List<Tag>> GetMatchAsync(string term)
        {
            using (IUnityContainer unit = IoCConfiguration.container.CreateChildContainer())
            {
                ITagsManager manager = unit.Resolve<ITagsManager>();

                List<Tag> tags = await manager.FetchTagsWithMatchingName(term);

                return tags;
            }
        }
    }
}
