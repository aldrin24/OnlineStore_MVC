namespace OnlineStore_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_ImageCommercialSlider
    {
        [Key]
        [Column(Order = 0)]
        public int Image_ID { get; set; }

        [Column(Order = 1)]
        [StringLength(50)]
        public string Image_Name { get; set; }

        [Column(Order = 2)]
        [StringLength(256)]
        public string Image_Path { get; set; }

        [NotMapped]
        public string Slider_Path { get; set; }

        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Image_Timer { get; set; }

        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Image_Active { get; set; }
    }
}
