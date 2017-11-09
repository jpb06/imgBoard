using ImgBoard.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Models.Main
{
    [Table("Comments")]
    public class Comment : BaseModel
    {
        /* ----------------------------------------------------------*/
        [ForeignKey("Creator")]     
        public int IdCreator { get; set; }
        [ForeignKey("Image")]
        public int IdImage { get; set; }
        /* ----------------------------------------------------------*/

        [Required]
        [StringLength(1024)]
        public string Message { get; set; }

        /* ----------------------------------------------------------*/
        public virtual User Creator { get; set; }
        public virtual Image Image { get; set; }
        /* ----------------------------------------------------------*/

        public Comment() : base()
        {
            
        }
    }
}
