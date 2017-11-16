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
    [Table("Images")]
    public class DbImage : BaseDbModel
    {
        /* ----------------------------------------------------------*/
        [ForeignKey("Category")]
        public int? IdCategory { get; set; }
        [ForeignKey("Uploader")]
        public int IdUploader { get; set; }
        /* ----------------------------------------------------------*/

        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(512)]
        public string Description { get; set; }

        [Required]
        public Guid FileId { get; set; }

        /* ----------------------------------------------------------*/
        public virtual DbCategory Category { get; set; }
        public virtual DbUser Uploader { get; set; }

        [InverseProperty("Image")]
        public virtual ICollection<DbComment> Comments { get; set; }

        // many to many
        public virtual ICollection<DbTag> Tags { get; set; }
        /* ----------------------------------------------------------*/

        public DbImage() : base()
        {
            this.Comments = new HashSet<DbComment>();
            this.Tags = new HashSet<DbTag>();
        }
    }
}
