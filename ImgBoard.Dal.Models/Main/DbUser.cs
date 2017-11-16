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
    [Table("Users")]
    public class DbUser : BaseDbModel
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
        public virtual ICollection<DbImage> UploadedImages { get; set; }
        [InverseProperty("Creator")]
        public virtual ICollection<DbComment> Comments { get; set; }
        /* ----------------------------------------------------------*/

        public DbUser() : base()
        {
            this.UploadedImages = new HashSet<DbImage>();
            this.Comments = new HashSet<DbComment>();
        }
    }
}
