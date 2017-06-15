using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace OnlineStore_MVC.Models
{
    public partial class tbl_Orders
    {
        [Key]
        public int Order_ID { get; set; }

        public int? Order_Number { get; set; }

        public DateTime? Order_Date { get; set; }

        public int? AccountID { get; set; }

        public virtual tbl_Accounts tbl_Accounts { get; set; }
    }
}
