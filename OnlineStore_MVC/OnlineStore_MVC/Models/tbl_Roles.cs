using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace OnlineStore_MVC.Models
{
    public partial class tbl_Roles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Roles()
        {
            tbl_Accounts = new HashSet<tbl_Accounts>();
        }

        [Key]
        public int Role_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Role_Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Accounts> tbl_Accounts { get; set; }
    }
}
