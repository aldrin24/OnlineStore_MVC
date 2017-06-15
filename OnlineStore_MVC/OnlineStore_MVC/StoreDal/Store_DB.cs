namespace OnlineStore_MVC
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models;

    public partial class Store_DB : DbContext
    {
        public Store_DB()
            : base("name=Store_DB")
        {
        }

        public virtual DbSet<tbl_Accounts> tbl_Accounts { get; set; }
        public virtual DbSet<tbl_Categories> tbl_Categories { get; set; }
        public virtual DbSet<tbl_Cities> tbl_Cities { get; set; }
        public virtual DbSet<tbl_ImageCommercialSlider> tbl_ImageCommercialSlider { get; set; }
        public virtual DbSet<tbl_Messages> tbl_Messages { get; set; }
        public virtual DbSet<tbl_MessagesReplay> tbl_MessagesReplay { get; set; }
        public virtual DbSet<tbl_Orders> tbl_Orders { get; set; }
        public virtual DbSet<tbl_Roles> tbl_Roles { get; set; }
        public virtual DbSet<tbl_SubCategories> tbl_SubCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Accounts>()
                .HasMany(e => e.tbl_Cities)
                .WithOptional(e => e.tbl_Accounts)
                .HasForeignKey(e => e.AccountID);

            modelBuilder.Entity<tbl_Accounts>()
                .HasMany(e => e.tbl_Orders)
                .WithOptional(e => e.tbl_Accounts)
                .HasForeignKey(e => e.AccountID);

            modelBuilder.Entity<tbl_Categories>();
        }

        public System.Data.Entity.DbSet<OnlineStore_MVC.Models.AccountsModel> AccountsModels { get; set; }

        //public System.Data.Entity.DbSet<Store_Project.Models.CategoriesModel> CategriesModels { get; set; }
    }
}
