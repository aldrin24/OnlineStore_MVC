using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineStore_MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore_MVC.Models
{
    public class OrdersModel
    {
        [Key]
        public int OrderID { get; set; }

        public Random OrderNumber = new Random(1);

        public DateTime OrderDate = DateTime.Now;

        [Key]
        public AccountsModel AccountID { get; set; }
    }
}