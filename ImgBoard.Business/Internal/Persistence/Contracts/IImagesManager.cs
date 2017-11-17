using ImgBoard.Dal.Models.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Business.Internal.Persistence.Contracts
{
    internal interface IImagesManager
    {
        Task<List<DbImage>> FetchImagesAsync();
        Task<List<DbImage>> FetchImagesByCategoryAsync(int categoryId);
        Task<List<DbImage>> FetchTaggedImagesAsync(int[] tagsIds);
    }
}
