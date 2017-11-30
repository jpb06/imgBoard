using ImgBoard.Business.Exceptions;
using ImgBoard.Business.Exceptions.CustomTypes;
using ImgBoard.Business.Exposed;
using ImgBoard.Business.Internal.Persistence.Contracts;
using ImgBoard.Dal.Manipulation.Services.Main.Contracts;
using ImgBoard.Dal.Models.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Business.Internal.Persistence
{
    internal class ImagesManager : IImagesManager
    {
        private IPersistenceService persistenceService;

        public ImagesManager(IPersistenceService persistenceService)
        {
            this.persistenceService = persistenceService;
        }

        public async Task<List<DbImage>> FetchImagesAsync()
        {
            var data = await this.persistenceService.GetAsync<DbImage>();

            return data.ToList();
        }

        public async Task<List<DbImage>> FetchImagesByCategoryAsync(int categoryId)
        {
            var data = await this.persistenceService.GetAsync<DbImage>(i => i.IdCategory == categoryId);

            return data.ToList();
        }
        public async Task<List<DbImage>> FetchTaggedImagesAsync(int[] tagsIds)
        {
            if (tagsIds == null || tagsIds.Length == 0)
                throw new BusinessException(BusinessErrorType.NoTagsSupplied);

            var data = await this.persistenceService.GetAsync<DbTag>(t => tagsIds.Contains(t.Id));

            return data.SelectMany(t => t.Images).ToList();
        }

        public async Task<List<DbImage>> FetchImagesMatchingCategory(string term)
        {
            var data = await this.persistenceService.GetAsync<DbImage>(filter: el => el.Category.Title.Contains(term));

            return data;
        }

        //public async Task<List<DbTag>> FetchMatchingTags(string criteria)
        //{
        //    var tags = await this.persistenceService.GetAsync<DbTag>(t => t.Name.Contains(criteria));

        //    return tags;
        //}
    }
}
