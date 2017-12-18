using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Models.Api
{
    public class GetImagesParameters
    {
        public int[] CategoriesIds { get; set; }
        public int[] TagsIds { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Uploader { get; set; }
        public string Extension { get; set; }
    }
}
