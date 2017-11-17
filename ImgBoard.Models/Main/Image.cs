using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Models.Main
{
    public class Image
    {
        public int Id { get; set; }
        public int? IdCategory { get; set; }
        public int IdUploader { get; set; }
        //--------------------------------------------
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid FileId { get; set; }
        public string FileExtension { get; set; }
        //--------------------------------------------
        public Category Category { get; set; }
        public User Uploader { get; set; }
    }
}
