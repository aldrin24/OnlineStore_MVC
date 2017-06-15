using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace OnlineStore_MVC.Models
{
    public partial class tbl_MessagesReplay
    {
        [Key]
        public int Replay_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Replay_UserName { get; set; }

        [StringLength(2000)]
        public string Replay_Content { get; set; }

        public int? Message_ID { get; set; }

        public virtual tbl_Messages tbl_Messages { get; set; }
    }
}
