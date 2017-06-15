using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace OnlineStore_MVC.Models
{
    public partial class tbl_SubCategories
    {
        [Key]
        public int SubCategory_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string SubCategory_Name { get; set; }

        [StringLength(1000)]
        public string SubCategory_Desc { get; set; }

        public int? Category_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string SubCategory_ImageName { get; set; }

        public virtual tbl_Categories tbl_Categories { get; set; }
    }
}
