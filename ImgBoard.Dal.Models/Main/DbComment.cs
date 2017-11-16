using ImgBoard.Dal.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Dal.Models.Main
{
    [Table("Comments")]
    public class DbComment : BaseDbModel
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
        public virtual DbUser Creator { get; set; }
        public virtual DbImage Image { get; set; }
        /* ----------------------------------------------------------*/

        public DbComment() : base()
        {
            
        }
    }
}
