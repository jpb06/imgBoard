using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Models.Main
{
    public class Comment
    {
        public int Id { get; set; }
        public int IdCreator { get; set; }
        public int IdImage { get; set; }
        //--------------------------------------------
        public string Message { get; set; }
        //--------------------------------------------
        public User Creator { get; set; }
        public Image Image { get; set; }
    }
}
