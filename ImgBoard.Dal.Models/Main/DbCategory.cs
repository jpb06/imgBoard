﻿using ImgBoard.Dal.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Dal.Models.Main
{
    [Table("Categories")]
    public class DbCategory : BaseDbModel
    {
        /* ----------------------------------------------------------*/

        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        /* ----------------------------------------------------------*/
        [InverseProperty("Category")]
        public virtual ICollection<DbImage> Images { get; set; }
        /* ----------------------------------------------------------*/

        public DbCategory() : base()
        {
            this.Images = new HashSet<DbImage>();
        }
    }
}
