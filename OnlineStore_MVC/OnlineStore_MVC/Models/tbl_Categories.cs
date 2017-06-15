using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Web;

namespace OnlineStore_MVC.Models
{
    public partial class tbl_Categories
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Categories()
        {
            tbl_SubCategories = new HashSet<tbl_SubCategories>();
        }

        [Key]
        [Column(Order = 0)]
        public int Category_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Category_Name { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        public string Category_ImageName { get; set; }

        [NotMapped]
        public string Category_ImagePath { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SubCategories> tbl_SubCategories { get; set; }
    }
}
