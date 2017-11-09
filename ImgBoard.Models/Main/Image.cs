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
    [Table("Images")]
    public class Image : BaseModel
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
        public virtual Category Category { get; set; }
        public virtual User Uploader { get; set; }

        [InverseProperty("Image")]
        public virtual ICollection<Comment> Comments { get; set; }

        // many to many
        public virtual ICollection<Tag> Tags { get; set; }
        /* ----------------------------------------------------------*/

        public Image() : base()
        {
            this.Comments = new HashSet<Comment>();
            this.Tags = new HashSet<Tag>();
        }
    }
}
