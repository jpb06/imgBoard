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
    [Table("Tags")]
    public class DbTag : BaseDbModel
    {
        /* ----------------------------------------------------------*/

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        /* ----------------------------------------------------------*/
        // many to many
        public virtual ICollection<DbImage> Images { get; set; }
        /* ----------------------------------------------------------*/

        public DbTag() : base()
        {
            this.Images = new HashSet<DbImage>();
        }
    }
}
