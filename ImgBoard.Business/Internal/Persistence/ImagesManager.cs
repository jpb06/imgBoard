using ImgBoard.Business.Exceptions;
using ImgBoard.Business.Exceptions.CustomTypes;
using ImgBoard.Business.Exposed;
using ImgBoard.Business.Internal.Persistence.Contracts;
using ImgBoard.Business.Util;
using ImgBoard.Dal.Manipulation.Services.Main.Contracts;
using ImgBoard.Dal.Models.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ImgBoard.Business.Util;

namespace ImgBoard.Business.Internal.Persistence
{
    internal class ImagesManager : IImagesManager
    {
        private IPersistenceService persistenceService;

        public ImagesManager(IPersistenceService persistenceService)
        {
            this.persistenceService = persistenceService;
        }

        public async Task<List<DbImage>> FetchImagesAsync(
            int[] tagsIds = null,
            int[] categoriesIds = null,
            string name = null,
            string description = null,
            string uploader = null,
            string extension = null)
        {
            List<Expression<Func<DbImage, bool>>> filters = new List<Expression<Func<DbImage, bool>>>();

            if (tagsIds != null)
                filters.Add(i => i.Tags.Any(t => tagsIds.Contains(t.Id)));

            if (categoriesIds != null)
                filters.Add(i => i.IdCategory.HasValue && categoriesIds.Contains(i.IdCategory.Value));

            if (name != null)
                filters.Add(i => i.Name != null && i.Name.Contains(name));

            if (description != null)
                filters.Add(i => i.Description != null && i.Description.Contains(description));

            if (uploader != null)
                filters.Add(i => i.Uploader.Login == uploader);

            if (extension != null)
                filters.Add(i => i.FileExtension == extension);

            var filter = filters.FirstOrDefault();
            for(int i = 1; i < filters.Count; i++)
                filter = filter.And(filters.ElementAt(i));

            var data = await this.persistenceService.GetAsync<DbImage>(filter);

            return data;
        }
    }
}
