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
    [Table("Categories")]
    public class Category : BaseModel
    {
        /* ----------------------------------------------------------*/

        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        /* ----------------------------------------------------------*/
        [InverseProperty("Category")]
        public virtual ICollection<Image> Images { get; set; }
        /* ----------------------------------------------------------*/

        public Category() : base()
        {
            this.Images = new HashSet<Image>();
        }
    }
}
