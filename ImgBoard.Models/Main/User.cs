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
    [Table("Users")]
    public class User : BaseModel
    {
        /* ----------------------------------------------------------*/

        [Required]
        [StringLength(128)]
        public string Login { get; set; }

        [Required]
        [StringLength(128)]
        public string Password { get; set; }

        [Required]
        [StringLength(128)]
        public string UserName { get; set; }

        /* ----------------------------------------------------------*/
        [InverseProperty("Uploader")]
        public virtual ICollection<Image> UploadedImages { get; set; }
        [InverseProperty("Creator")]
        public virtual ICollection<Comment> Comments { get; set; }
        /* ----------------------------------------------------------*/

        public User() : base()
        {
            this.UploadedImages = new HashSet<Image>();
            this.Comments = new HashSet<Comment>();
        }
    }
}
