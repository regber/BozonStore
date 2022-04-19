using BozonStore.Models.ProductModel;
using Microsoft.EntityFrameworkCore;
using BozonStore.Models.ProductModel.Product.HomeAppliances;
using BozonStore.Models.ProductModel.Product.Electronics;
using BozonStore.Models.ProductModel.Product.ConstrAndRepair;

namespace BozonStore.Models
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public  DbSet<Seller> Sellers { get; set; }
        public DbSet<Purchas> Purchases { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }

        public DbSet<BaseProduct> Products { get; set; }
        //HomeAppliances
        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<Stove> Stoves { get; set; }
        public DbSet<WashingMachine> WashingMachines { get; set; }
        //Electronics
        public DbSet<Audio> Audios { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseProduct>().ToTable("BaseProducts");

            modelBuilder.Entity<Fridge>().ToTable("Fridges");
            modelBuilder.Entity<Stove>().ToTable("Stoves");
            modelBuilder.Entity<WashingMachine>().ToTable("WashingMachines");

            base.OnModelCreating(modelBuilder);
        }
    }
}
