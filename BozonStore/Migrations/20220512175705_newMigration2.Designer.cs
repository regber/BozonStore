﻿// <auto-generated />
using System;
using BozonStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BozonStore.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220512175705_newMigration2")]
    partial class newMigration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BozonStore.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.CommonClass.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<byte>("Alpha")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Blue")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Green")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Red")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Color");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MainImageId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("ShopId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MainImageId");

                    b.HasIndex("ShopId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BozonStore.Models.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("BuyerId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Seller")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SellerShop")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("BozonStore.Models.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("BozonStore.Models.UserModel.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Products.ConstrAndRepair.BathroomEquip.Mixer", b =>
                {
                    b.HasBaseType("BozonStore.Models.ProductModel.Product");

                    b.Property<int?>("ColorId")
                        .HasColumnType("int");

                    b.Property<string>("Features")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Installation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Purpose")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("ColorId");

                    b.ToTable("Mixers");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Products.ConstrAndRepair.BathroomEquip.Sink", b =>
                {
                    b.HasBaseType("BozonStore.Models.ProductModel.Product");

                    b.Property<int>("CupCount")
                        .HasColumnType("int");

                    b.Property<string>("Installation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.ToTable("Sinks");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Products.ConstrAndRepair.ElectricyTool.AngleGrinder", b =>
                {
                    b.HasBaseType("BozonStore.Models.ProductModel.Product");

                    b.Property<int>("DiameterDisc")
                        .HasColumnType("int");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.ToTable("AngleGrinders");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Products.ConstrAndRepair.ElectricyTool.Puncher", b =>
                {
                    b.HasBaseType("BozonStore.Models.ProductModel.Product");

                    b.Property<string>("HolderType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.Property<int>("SpeedCount")
                        .HasColumnType("int");

                    b.Property<int>("Turnovers")
                        .HasColumnType("int");

                    b.ToTable("Punchers");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Products.ConstrAndRepair.FinishingMat.WallpaperAndCoatings.WallPanel", b =>
                {
                    b.HasBaseType("BozonStore.Models.ProductModel.Product");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<int>("Thickness")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.ToTable("WallPanels");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Products.ConstrAndRepair.FinishingMat.WallpaperAndCoatings.Wallpaper", b =>
                {
                    b.HasBaseType("BozonStore.Models.ProductModel.Product");

                    b.Property<string>("Article")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Length")
                        .HasColumnType("real");

                    b.Property<string>("WallpaperType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Width")
                        .HasColumnType("real");

                    b.ToTable("Wallpapers");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Products.Electronics.Audio", b =>
                {
                    b.HasBaseType("BozonStore.Models.ProductModel.Product");

                    b.Property<int?>("ColorId")
                        .HasColumnType("int");

                    b.HasIndex("ColorId");

                    b.ToTable("Audios");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Products.Electronics.Computer", b =>
                {
                    b.HasBaseType("BozonStore.Models.ProductModel.Product");

                    b.Property<int?>("ColorId")
                        .HasColumnType("int");

                    b.Property<float>("Frequency")
                        .HasColumnType("real");

                    b.Property<int>("HardDriveSize")
                        .HasColumnType("int");

                    b.Property<string>("OSType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcessorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RAMType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RAMVolume")
                        .HasColumnType("int");

                    b.Property<string>("VideoCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoCardType")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("ColorId");

                    b.ToTable("Computers");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Products.Electronics.Smartphone", b =>
                {
                    b.HasBaseType("BozonStore.Models.ProductModel.Product");

                    b.Property<int>("BatteryVolume")
                        .HasColumnType("int");

                    b.Property<string>("BodyMaterialType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ColorId")
                        .HasColumnType("int");

                    b.Property<int>("CoreCount")
                        .HasColumnType("int");

                    b.Property<float>("Diagonal")
                        .HasColumnType("real");

                    b.Property<int>("EmbeddedMemoryVolume")
                        .HasColumnType("int");

                    b.Property<int>("HorizontalResolution")
                        .HasColumnType("int");

                    b.Property<string>("MemoryCardType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RAMVolume")
                        .HasColumnType("int");

                    b.Property<int>("VerticalResolution")
                        .HasColumnType("int");

                    b.Property<string>("_WirelessInterface")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("WirelessInterface");

                    b.HasIndex("ColorId");

                    b.ToTable("Smartphones");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Products.Electronics.Television", b =>
                {
                    b.HasBaseType("BozonStore.Models.ProductModel.Product");

                    b.Property<string>("BracingType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ColorId")
                        .HasColumnType("int");

                    b.Property<int>("CountHDMI")
                        .HasColumnType("int");

                    b.Property<int>("Diagonal")
                        .HasColumnType("int");

                    b.Property<int>("Frequency")
                        .HasColumnType("int");

                    b.Property<bool>("FullHD")
                        .HasColumnType("bit");

                    b.Property<bool>("HD")
                        .HasColumnType("bit");

                    b.Property<int>("HorizontalResolution")
                        .HasColumnType("int");

                    b.Property<string>("LightingType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatrixType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SmartTV")
                        .HasColumnType("bit");

                    b.Property<int>("VerticalResolution")
                        .HasColumnType("int");

                    b.Property<string>("WirelessInterface")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("ColorId");

                    b.ToTable("Televisions");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Products.HomeAppliances.Fridge", b =>
                {
                    b.HasBaseType("BozonStore.Models.ProductModel.Product");

                    b.Property<int?>("ColorId")
                        .HasColumnType("int");

                    b.Property<string>("CompressorType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CoolingVolume")
                        .HasColumnType("int");

                    b.Property<string>("DefrostingType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Depth")
                        .HasColumnType("int");

                    b.Property<bool>("Embedded")
                        .HasColumnType("bit");

                    b.Property<string>("EnergyConsumptionClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FreezerVolume")
                        .HasColumnType("int");

                    b.Property<int>("FreezingPower")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("TotalVolume")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasIndex("ColorId");

                    b.ToTable("Fridges");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Products.HomeAppliances.Stove", b =>
                {
                    b.HasBaseType("BozonStore.Models.ProductModel.Product");

                    b.Property<string>("BurnersType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ColorId")
                        .HasColumnType("int");

                    b.Property<string>("ControlType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Depth")
                        .HasColumnType("int");

                    b.Property<bool>("Embedded")
                        .HasColumnType("bit");

                    b.Property<string>("EnergyConsumptionClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("OvenType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OvenVolume")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasIndex("ColorId");

                    b.ToTable("Stoves");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Products.HomeAppliances.WashingMachine", b =>
                {
                    b.HasBaseType("BozonStore.Models.ProductModel.Product");

                    b.Property<int?>("ColorId")
                        .HasColumnType("int");

                    b.Property<string>("ControlType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Depth")
                        .HasColumnType("int");

                    b.Property<bool>("DirectDrive")
                        .HasColumnType("bit");

                    b.Property<bool>("Embedded")
                        .HasColumnType("bit");

                    b.Property<string>("EnergyConsumptionClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HaveDrying")
                        .HasColumnType("bit");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("SpinClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpinSpeed")
                        .HasColumnType("int");

                    b.Property<float>("Volume")
                        .HasColumnType("real");

                    b.Property<string>("WashingClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasIndex("ColorId");

                    b.ToTable("WashingMachines");
                });

            modelBuilder.Entity("BozonStore.Models.UserModel.Buyer", b =>
                {
                    b.HasBaseType("BozonStore.Models.UserModel.User");

                    b.ToTable("Buyers");
                });

            modelBuilder.Entity("BozonStore.Models.UserModel.Delivery", b =>
                {
                    b.HasBaseType("BozonStore.Models.UserModel.User");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Deliverys");
                });

            modelBuilder.Entity("BozonStore.Models.UserModel.Seller", b =>
                {
                    b.HasBaseType("BozonStore.Models.UserModel.User");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("BozonStore.Models.Image", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.Product", null)
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product", b =>
                {
                    b.HasOne("BozonStore.Models.Image", "MainImage")
                        .WithMany()
                        .HasForeignKey("MainImageId");

                    b.HasOne("BozonStore.Models.Shop", null)
                        .WithMany("Products")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("MainImage");
                });

            modelBuilder.Entity("BozonStore.Models.Purchase", b =>
                {
                    b.HasOne("BozonStore.Models.UserModel.Buyer", null)
                        .WithMany("Purchases")
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BozonStore.Models.ProductModel.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BozonStore.Models.Shop", b =>
                {
                    b.HasOne("BozonStore.Models.UserModel.Seller", "Seller")
                        .WithMany("Shops")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Products.ConstrAndRepair.BathroomEquip.Mixer", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.CommonClass.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId");

                    b.HasOne("BozonStore.Models.ProductModel.Product", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.ProductModel.Products.ConstrAndRepair.BathroomEquip.Mixer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Products.ConstrAndRepair.BathroomEquip.Sink", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.Product", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.ProductModel.Products.ConstrAndRepair.BathroomEquip.Sink", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Products.ConstrAndRepair.ElectricyTool.AngleGrinder", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.Product", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.ProductModel.Products.ConstrAndRepair.ElectricyTool.AngleGrinder", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Products.ConstrAndRepair.ElectricyTool.Puncher", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.Product", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.ProductModel.Products.ConstrAndRepair.ElectricyTool.Puncher", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Products.ConstrAndRepair.FinishingMat.WallpaperAndCoatings.WallPanel", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.Product", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.ProductModel.Products.ConstrAndRepair.FinishingMat.WallpaperAndCoatings.WallPanel", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Products.ConstrAndRepair.FinishingMat.WallpaperAndCoatings.Wallpaper", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.Product", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.ProductModel.Products.ConstrAndRepair.FinishingMat.WallpaperAndCoatings.Wallpaper", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Products.Electronics.Audio", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.CommonClass.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId");

                    b.HasOne("BozonStore.Models.ProductModel.Product", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.ProductModel.Products.Electronics.Audio", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Products.Electronics.Computer", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.CommonClass.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId");

                    b.HasOne("BozonStore.Models.ProductModel.Product", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.ProductModel.Products.Electronics.Computer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Products.Electronics.Smartphone", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.CommonClass.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId");

                    b.HasOne("BozonStore.Models.ProductModel.Product", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.ProductModel.Products.Electronics.Smartphone", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Products.Electronics.Television", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.CommonClass.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId");

                    b.HasOne("BozonStore.Models.ProductModel.Product", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.ProductModel.Products.Electronics.Television", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Products.HomeAppliances.Fridge", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.CommonClass.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId");

                    b.HasOne("BozonStore.Models.ProductModel.Product", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.ProductModel.Products.HomeAppliances.Fridge", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Products.HomeAppliances.Stove", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.CommonClass.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId");

                    b.HasOne("BozonStore.Models.ProductModel.Product", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.ProductModel.Products.HomeAppliances.Stove", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Products.HomeAppliances.WashingMachine", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.CommonClass.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId");

                    b.HasOne("BozonStore.Models.ProductModel.Product", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.ProductModel.Products.HomeAppliances.WashingMachine", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");
                });

            modelBuilder.Entity("BozonStore.Models.UserModel.Buyer", b =>
                {
                    b.HasOne("BozonStore.Models.UserModel.User", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.UserModel.Buyer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BozonStore.Models.UserModel.Delivery", b =>
                {
                    b.HasOne("BozonStore.Models.UserModel.User", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.UserModel.Delivery", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BozonStore.Models.UserModel.Seller", b =>
                {
                    b.HasOne("BozonStore.Models.UserModel.User", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.UserModel.Seller", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("BozonStore.Models.Shop", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("BozonStore.Models.UserModel.Buyer", b =>
                {
                    b.Navigation("Purchases");
                });

            modelBuilder.Entity("BozonStore.Models.UserModel.Seller", b =>
                {
                    b.Navigation("Shops");
                });
#pragma warning restore 612, 618
        }
    }
}
