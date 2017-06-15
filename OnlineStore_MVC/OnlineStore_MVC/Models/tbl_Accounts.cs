using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Web.Mvc;

namespace OnlineStore_MVC.Models
{
    public partial class tbl_Accounts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Accounts()
        {
            tbl_Cities = new HashSet<tbl_Cities>();
            tbl_Orders = new HashSet<tbl_Orders>();
        }

        [Key]
        public int Account_ID { get; set; }

        [StringLength(50)]
        public string Account_FirstName { get; set; }

        [StringLength(50)]
        public string Account_LastName { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Account_BirthDate { get; set; }

        [StringLength(100)]
        public string Account_EmailAddress { get; set; }

        [StringLength(50)]
        public string Account_Country { get; set; }

        [StringLength(50)]
        public string Account_City { get; set; }

        public int? City_ID { get; set; }

        public int? Account_Mobile { get; set; }

        public int? Account_Phone { get; set; }

        [StringLength(50)]
        public string Account_UserName { get; set; }

        [StringLength(30)]
        public string Account_Password { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        public string Account_ImageName { get; set; }

        [NotMapped]
        public string Account_ImagePath { get; set; }

        public int? Role_ID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Account_CreatedDate { get; set; }

        public virtual tbl_Roles tbl_Roles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Cities> tbl_Cities { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Orders> tbl_Orders { get; set; }
    }
}
