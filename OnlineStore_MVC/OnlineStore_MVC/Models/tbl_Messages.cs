using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace OnlineStore_MVC.Models
{
    public partial class tbl_Messages
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Messages()
        {
            tbl_MessagesReplay = new HashSet<tbl_MessagesReplay>();
        }

        [Key]
        public int Message_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Message_UserName { get; set; }

        [StringLength(2000)]
        public string Message_Content { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_MessagesReplay> tbl_MessagesReplay { get; set; }
    }
}
