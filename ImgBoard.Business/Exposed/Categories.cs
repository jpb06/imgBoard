﻿using ImgBoard.Business.Internal.Persistence.Contracts;
using ImgBoard.Business.InversionOfControl;
using ImgBoard.Dal.Models.Main;
using ImgBoard.Models.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ImgBoard.Business.Exposed
{
    public static class Categories
    {
        public static async Task<List<Category>> GetMatchAsync(string term)
        {
            using (IUnityContainer unit = IoCConfiguration.container.CreateChildContainer())
            {
                ICategoriesManager manager = unit.Resolve<ICategoriesManager>();

                List<Category> categories = await manager.FetchCategoriesWithMatchingTitle(term);

                return categories;
            }
        }
    }
}
