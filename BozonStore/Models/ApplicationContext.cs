using BozonStore.Models.ProductModel;
using Microsoft.EntityFrameworkCore;
using BozonStore.Models.ProductModel.Products.HomeAppliances;
using BozonStore.Models.ProductModel.Products.Electronics;
using ConstrAndRepair = BozonStore.Models.ProductModel.Products.ConstrAndRepair;
using BozonStore.Models.PurchaseModel;
using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

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
        
        //Purchas Model
        public DbSet<PurchaseProduct> PurchasProducts { get; set; }
        public DbSet<PurchaseSeller> PurchasSellers { get; set; }
        public DbSet<PurchaseShop> PurchasShops { get; set; }
        
        //HomeAppliances
        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<Stove> Stoves { get; set; }
        public DbSet<WashingMachine> WashingMachines { get; set; }
        //Electronics
        public DbSet<Audio> Audios { get; set; }
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
            modelBuilder.Entity<Smartphone>().Property("_WirelessInterface").HasColumnName("WirelessInterface");

            //Генерируем для указанных базовых типов(User,Product,PurchaseProduct) отдельные таблицы в базе для их производных
            //типов, а также указываем что производные типы имеют каскадное удаление при удалении из базы записи базового типа
            ConfigureChildrenEntities<User>(modelBuilder);
            ConfigureChildrenEntities<Product>(modelBuilder);
            ConfigureChildrenEntities<PurchaseProduct>(modelBuilder);

            modelBuilder.Entity<Image>().ToTable("Images");
            modelBuilder.Entity<Product>().HasMany(p => p.Images).WithOne().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Buyer>().HasMany(b => b.Purchases).WithOne().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PurchaseImage>().ToTable("PurchaseImages");
            modelBuilder.Entity<PurchaseProduct>().Property(p => p.SellerId).HasColumnName("PurchaseSellerId");
            modelBuilder.Entity<PurchaseProduct>().HasMany(p => p.Images).WithOne().OnDelete(DeleteBehavior.Cascade);

            //IncludeCommonTPT(modelBuilder);
            //IncludeBaseProductTPT(modelBuilder);
            //IncludePurchaseModelTPT(modelBuilder);
            //IncludeHomeAppliancesTPT(modelBuilder);
            //IncludeElectronicsTPT(modelBuilder);
            //IncludeConstrAndRepairTPT(modelBuilder);
            
            base.OnModelCreating(modelBuilder);
        }

        private void IncludeCommonTPT(ModelBuilder modelBuilder) 
        {
            /*
            modelBuilder.Entity<Seller>().ToTable("Sellers");
            modelBuilder.Entity<Buyer>().ToTable("Buyers");
            modelBuilder.Entity<Delivery>().ToTable("Deliveries");
            */
            //modelBuilder.Entity<Seller>().HasOne<User>().WithOne().HasForeignKey<Seller>(p => p.Id).OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Buyer>().HasOne<User>().WithOne().HasForeignKey<Buyer>(p => p.Id).OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Delivery>().HasOne<User>().WithOne().HasForeignKey<Delivery>(p => p.Id).OnDelete(DeleteBehavior.Cascade);

            

        }

        public static void ConfigureChildrenEntities<ParentType>(ModelBuilder modelBuilder) where ParentType : class
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






        private void IncludeBaseProductTPT(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Image>().ToTable("Images");
            modelBuilder.Entity<Product>().HasMany(p => p.Images).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
        private void IncludePurchaseModelTPT(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<PurchaseProduct>().ToTable("PurchaseProducts");
            modelBuilder.Entity<PurchaseImage>().ToTable("PurchaseImages");
            //modelBuilder.Entity<PurchaseSeller>().ToTable("PurchaseSellers");

            modelBuilder.Entity<PurchaseProduct>().Property(p => p.SellerId).HasColumnName("PurchaseSellerId");

            modelBuilder.Entity<PurchaseProduct>().HasMany(p => p.Images).WithOne().OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<PurchaseSeller>().HasOne<User>().WithOne().HasForeignKey<PurchaseSeller>(p => p.Id).OnDelete(DeleteBehavior.Cascade);

        }
        private void IncludeHomeAppliancesTPT(ModelBuilder modelBuilder)
        {/*
            //HomeAppliances
            modelBuilder.Entity<Fridge>().ToTable("Fridges");
            modelBuilder.Entity<Stove>().ToTable("Stoves");
            modelBuilder.Entity<WashingMachine>().ToTable("WashingMachines");

            modelBuilder.Entity<Fridge>().HasOne<Product>().WithOne().HasForeignKey<Fridge>(p => p.Id).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Stove>().HasOne<Product>().WithOne().HasForeignKey<Stove>(p => p.Id).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<WashingMachine>().HasOne<Product>().WithOne().HasForeignKey<WashingMachine>(p => p.Id).OnDelete(DeleteBehavior.Cascade);*/
        }
        private void IncludeElectronicsTPT(ModelBuilder modelBuilder)
        {/*
            //Electronics
            modelBuilder.Entity<Audio>().ToTable("Audios");
            modelBuilder.Entity<Computer>().ToTable("Computers");
            modelBuilder.Entity<Smartphone>().ToTable("Smartphones");
            modelBuilder.Entity<Television>().ToTable("Televisions");

            modelBuilder.Entity<Audio>().HasOne<Product>().WithOne().HasForeignKey<Audio>(p => p.Id).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Computer>().HasOne<Product>().WithOne().HasForeignKey<Computer>(p => p.Id).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Smartphone>().HasOne<Product>().WithOne().HasForeignKey<Smartphone>(p => p.Id).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Television>().HasOne<Product>().WithOne().HasForeignKey<Television>(p => p.Id).OnDelete(DeleteBehavior.Cascade);
        */}
        private void IncludeConstrAndRepairTPT(ModelBuilder modelBuilder)
        {/*
            //ConstrAndRepair
            modelBuilder.Entity<ConstrAndRepair.BathroomEquip.Mixer>().ToTable("Mixers");
            modelBuilder.Entity<ConstrAndRepair.BathroomEquip.Sink>().ToTable("Sinks");
            modelBuilder.Entity<ConstrAndRepair.ElectricyTool.AngleGrinder>().ToTable("AngleGrinders");
            modelBuilder.Entity<ConstrAndRepair.ElectricyTool.Puncher>().ToTable("Punchers");
            modelBuilder.Entity<ConstrAndRepair.FinishingMat.WallpaperAndCoatings.WallPanel>().ToTable("WallPanels");
            modelBuilder.Entity<ConstrAndRepair.FinishingMat.WallpaperAndCoatings.Wallpaper>().ToTable("Wallpapers");

            modelBuilder.Entity<ConstrAndRepair.BathroomEquip.Mixer>().HasOne<Product>().WithOne().HasForeignKey<ConstrAndRepair.BathroomEquip.Mixer>(p => p.Id).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ConstrAndRepair.BathroomEquip.Sink>().HasOne<Product>().WithOne().HasForeignKey<ConstrAndRepair.BathroomEquip.Sink>(p => p.Id).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ConstrAndRepair.ElectricyTool.AngleGrinder>().HasOne<Product>().WithOne().HasForeignKey<ConstrAndRepair.ElectricyTool.AngleGrinder>(p => p.Id).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ConstrAndRepair.ElectricyTool.Puncher>().HasOne<Product>().WithOne().HasForeignKey<ConstrAndRepair.ElectricyTool.Puncher>(p => p.Id).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ConstrAndRepair.FinishingMat.WallpaperAndCoatings.WallPanel>().HasOne<Product>().WithOne().HasForeignKey<ConstrAndRepair.FinishingMat.WallpaperAndCoatings.WallPanel>(p => p.Id).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ConstrAndRepair.FinishingMat.WallpaperAndCoatings.Wallpaper>().HasOne<Product>().WithOne().HasForeignKey<ConstrAndRepair.FinishingMat.WallpaperAndCoatings.Wallpaper>(p => p.Id).OnDelete(DeleteBehavior.Cascade);
        */}
    }
}
