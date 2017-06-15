using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace OnlineStore_MVC.Models
{
    public partial class tbl_Cities
    {
        [Key]
        public int City_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string City_Name { get; set; }

        public int? AccountID { get; set; }

        public virtual tbl_Accounts tbl_Accounts { get; set; }
    }
}
