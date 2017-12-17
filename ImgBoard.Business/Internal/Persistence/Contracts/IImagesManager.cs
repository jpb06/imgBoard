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
        Task<List<DbImage>> FetchImagesAsync(
            int[] tagsIds = null,
            int[] categoriesIds = null,
            string name = null,
            string description = null,
            string uploader = null,
            string extension = null);
    }
}
