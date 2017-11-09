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
    [Table("Tags")]
    public class Tag : BaseModel
    {
        /* ----------------------------------------------------------*/

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        /* ----------------------------------------------------------*/
        // many to many
        public virtual ICollection<Image> Images { get; set; }
        /* ----------------------------------------------------------*/

        public Tag() : base()
        {
            this.Images = new HashSet<Image>();
        }
    }
}
