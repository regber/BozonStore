﻿using BozonStore.Models.ProductModel;
using Microsoft.EntityFrameworkCore;
using BozonStore.Models.ProductModel.Products.HomeAppliances;
using BozonStore.Models.ProductModel.Products.Electronics;
using ConstrAndRepair = BozonStore.Models.ProductModel.Products.ConstrAndRepair;
using BozonStore.Models.PurchaseModel;
using System;

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

            IncludeBaseProductTPT(modelBuilder);
            IncludePurchasModelTPT(modelBuilder);
            IncludeHomeAppliancesTPT(modelBuilder);
            IncludeElectronicsTPT(modelBuilder);
            IncludeConstrAndRepairTPT(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }



        private void IncludeBaseProductTPT(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
        }
        private void IncludePurchasModelTPT(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PurchaseProduct>().ToTable("PurchaseProducts");
        }
        private void IncludeHomeAppliancesTPT(ModelBuilder modelBuilder)
        {
            //HomeAppliances
            modelBuilder.Entity<Fridge>().ToTable("Fridges");
            modelBuilder.Entity<Stove>().ToTable("Stoves");
            modelBuilder.Entity<WashingMachine>().ToTable("WashingMachines");
        }
        private void IncludeElectronicsTPT(ModelBuilder modelBuilder)
        {
            //Electronics
            modelBuilder.Entity<Audio>().ToTable("Audios");
            modelBuilder.Entity<Computer>().ToTable("Computers");
            modelBuilder.Entity<Smartphone>().ToTable("Smartphones");
            modelBuilder.Entity<Television>().ToTable("Televisions");
        }
        private void IncludeConstrAndRepairTPT(ModelBuilder modelBuilder)
        {
            //ConstrAndRepair
            modelBuilder.Entity<ConstrAndRepair.BathroomEquip.Mixer>().ToTable("Mixers");
            modelBuilder.Entity<ConstrAndRepair.BathroomEquip.Sink>().ToTable("Sinks");
            modelBuilder.Entity<ConstrAndRepair.ElectricyTool.AngleGrinder>().ToTable("AngleGrinders");
            modelBuilder.Entity<ConstrAndRepair.ElectricyTool.Puncher>().ToTable("Punchers");
            modelBuilder.Entity<ConstrAndRepair.FinishingMat.WallpaperAndCoatings.WallPanel>().ToTable("WallPanels");
            modelBuilder.Entity<ConstrAndRepair.FinishingMat.WallpaperAndCoatings.Wallpaper>().ToTable("Wallpapers");
        }
    }
}
