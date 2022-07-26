using BozonStore.Models.ProductModel;
using Microsoft.EntityFrameworkCore;
using BozonStore.Models.ProductModel.Products.HomeAppliances;
using BozonStore.Models.ProductModel.Products.Electronics;
using ConstrAndRepair = BozonStore.Models.ProductModel.Products.ConstrAndRepair;
using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using BozonStore.Models.UserModel;
using BozonStore.Models.ProductModel.Products.Electronics.Audios;

namespace BozonStore.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }


        public DbSet<Product> Products { get; set; }
        
        public DbSet<Purchase> Purchases { get; set; }
        

        //HomeAppliances
        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<Stove> Stoves { get; set; }
        public DbSet<WashingMachine> WashingMachines { get; set; }
        //Electronics
        public DbSet<Headphones> Headphones { get; set; }
        public DbSet<Speakers> Speakers { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Smartphone> Smartphones { get; set; }
        public DbSet<Television> Televisions { get; set; }
        //ConstrAndRepair
        public DbSet<ConstrAndRepair.BathroomEquip.Mixer> Mixers { get; set; }
        public DbSet<ConstrAndRepair.BathroomEquip.Sink> Sinks { get; set; }
        public DbSet<ConstrAndRepair.ElectricyTool.AngleGrinder> AngleGrinders { get; set; }
        public DbSet<ConstrAndRepair.ElectricyTool.Puncher> Punchers { get; set; }
        public DbSet<ConstrAndRepair.FinishingMat.WallpaperAndCoatings.WallPanel> WallPanels { get; set; }
        public DbSet<ConstrAndRepair.FinishingMat.WallpaperAndCoatings.Wallpaper> Wallpapers { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Smartphone>().Property("_WirelessInterface").HasColumnName("WirelessInterface");

            //Генерируем для указанных базовых типов(User,Product) отдельные таблицы в базе для их производных
            //типов, а также указываем что производные типы имеют каскадное удаление при удалении из базы записи базового типа
            ConfigureChildrenEntities<User>(modelBuilder);
            ConfigureChildrenEntities<Product>(modelBuilder);

            modelBuilder.Entity<Image>().ToTable("Images");
            modelBuilder.Entity<Product>().HasMany(p => p.Images).WithOne().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Shop>().HasMany(p => p.Products).WithOne().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Buyer>().HasMany(b => b.Purchases).WithOne().OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);
        }

        private static void ConfigureChildrenEntities<ParentType>(ModelBuilder modelBuilder) where ParentType : class
        {
            var childrenTypes = GetLastChildrenClass(typeof(ParentType));

            foreach (var childType in childrenTypes)
            {
                MethodInfo method = typeof(ApplicationContext).GetMethod(nameof(ApplicationContext.ConfigureEntities));
                MethodInfo generic = method.MakeGenericMethod(childType, typeof(ParentType));
                generic.Invoke(null, new object[] { modelBuilder });
            }
        }
        private static IEnumerable<Type> GetLastChildrenClass(Type parentType)
        {
            List<Type> types = new List<Type>();

            var children = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType == parentType).ToArray();

            foreach (Type child in children)
            {
                if (Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType == child).ToArray().Count() > 0)
                {
                    types.AddRange(GetLastChildrenClass(child));
                }
                else
                {
                    types.Add(child);
                }
            }

            return types;
        }
        public static void ConfigureEntities<ChildType,ParentType>(ModelBuilder modelBuilder) where ChildType : class
                                                                                              where ParentType : class
        {
            modelBuilder.Entity<ChildType>().ToTable(typeof(ChildType).Name+"s");
            modelBuilder.Entity<ChildType>().HasOne<ParentType>()
                                            .WithOne()
                                            .HasForeignKey<ChildType>("Id")
                                            .OnDelete(DeleteBehavior.Cascade);
        }


    }
}
