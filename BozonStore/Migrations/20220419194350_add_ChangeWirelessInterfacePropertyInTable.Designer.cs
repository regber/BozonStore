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
    [Migration("20220419194350_add_ChangeWirelessInterfacePropertyInTable")]
    partial class add_ChangeWirelessInterfacePropertyInTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BozonStore.Models.Delivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.HasKey("Id");

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("BozonStore.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("BaseProductId")
                        .HasColumnType("int");

                    b.Property<string>("Uri")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BaseProductId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.BaseProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Discription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MainImageId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.Property<int?>("SellerShopId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MainImageId");

                    b.HasIndex("SellerId");

                    b.HasIndex("SellerShopId");

                    b.ToTable("BaseProducts");
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

            modelBuilder.Entity("BozonStore.Models.Purchas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("BuyerId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("SellerId")
                        .HasColumnType("int");

                    b.Property<int?>("SellerShopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SellerId");

                    b.HasIndex("SellerShopId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("BozonStore.Models.SellerShop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.ToTable("SellerShop");
                });

            modelBuilder.Entity("BozonStore.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product.ConstrAndRepair.BathroomEquip.Mixer", b =>
                {
                    b.HasBaseType("BozonStore.Models.ProductModel.BaseProduct");

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

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product.ConstrAndRepair.BathroomEquip.Sink", b =>
                {
                    b.HasBaseType("BozonStore.Models.ProductModel.BaseProduct");

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

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product.ConstrAndRepair.ElectricyTool.AngleGrinder", b =>
                {
                    b.HasBaseType("BozonStore.Models.ProductModel.BaseProduct");

                    b.Property<int>("DiameterDisc")
                        .HasColumnType("int");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.ToTable("AngleGrinders");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product.ConstrAndRepair.ElectricyTool.Puncher", b =>
                {
                    b.HasBaseType("BozonStore.Models.ProductModel.BaseProduct");

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

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product.ConstrAndRepair.FinishingMat.WallpaperAndCoatings.WallPanel", b =>
                {
                    b.HasBaseType("BozonStore.Models.ProductModel.BaseProduct");

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

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product.ConstrAndRepair.FinishingMat.WallpaperAndCoatings.Wallpaper", b =>
                {
                    b.HasBaseType("BozonStore.Models.ProductModel.BaseProduct");

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

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product.Electronics.Audio", b =>
                {
                    b.HasBaseType("BozonStore.Models.ProductModel.BaseProduct");

                    b.Property<int?>("ColorId")
                        .HasColumnType("int");

                    b.HasIndex("ColorId");

                    b.ToTable("Audios");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product.Electronics.Computer", b =>
                {
                    b.HasBaseType("BozonStore.Models.ProductModel.BaseProduct");

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

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product.Electronics.Smartphone", b =>
                {
                    b.HasBaseType("BozonStore.Models.ProductModel.BaseProduct");

                    b.Property<int>("BatteryVolume")
                        .HasColumnType("int");

                    b.Property<string>("BodyMaterialType")
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
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("WirelessInterface");

                    b.HasIndex("ColorId");

                    b.ToTable("Smartphones");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product.Electronics.Television", b =>
                {
                    b.HasBaseType("BozonStore.Models.ProductModel.BaseProduct");

                    b.Property<string>("BracingType")
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatrixType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SmartTV")
                        .HasColumnType("bit");

                    b.Property<int>("VerticalResolution")
                        .HasColumnType("int");

                    b.Property<string>("WirelessInterface")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("ColorId");

                    b.ToTable("Televisions");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product.HomeAppliances.Fridge", b =>
                {
                    b.HasBaseType("BozonStore.Models.ProductModel.BaseProduct");

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

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product.HomeAppliances.Stove", b =>
                {
                    b.HasBaseType("BozonStore.Models.ProductModel.BaseProduct");

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

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product.HomeAppliances.WashingMachine", b =>
                {
                    b.HasBaseType("BozonStore.Models.ProductModel.BaseProduct");

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

            modelBuilder.Entity("BozonStore.Models.Buyer", b =>
                {
                    b.HasBaseType("BozonStore.Models.User");

                    b.HasDiscriminator().HasValue("Buyer");
                });

            modelBuilder.Entity("BozonStore.Models.Seller", b =>
                {
                    b.HasBaseType("BozonStore.Models.User");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Seller");
                });

            modelBuilder.Entity("BozonStore.Models.Image", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.BaseProduct", null)
                        .WithMany("Images")
                        .HasForeignKey("BaseProductId");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.BaseProduct", b =>
                {
                    b.HasOne("BozonStore.Models.Image", "MainImage")
                        .WithMany()
                        .HasForeignKey("MainImageId");

                    b.HasOne("BozonStore.Models.Seller", "Seller")
                        .WithMany()
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BozonStore.Models.SellerShop", null)
                        .WithMany("Products")
                        .HasForeignKey("SellerShopId");

                    b.Navigation("MainImage");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("BozonStore.Models.Purchas", b =>
                {
                    b.HasOne("BozonStore.Models.Buyer", null)
                        .WithMany("Purchases")
                        .HasForeignKey("BuyerId");

                    b.HasOne("BozonStore.Models.ProductModel.BaseProduct", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("BozonStore.Models.Seller", "Seller")
                        .WithMany()
                        .HasForeignKey("SellerId");

                    b.HasOne("BozonStore.Models.SellerShop", "SellerShop")
                        .WithMany()
                        .HasForeignKey("SellerShopId");

                    b.Navigation("Product");

                    b.Navigation("Seller");

                    b.Navigation("SellerShop");
                });

            modelBuilder.Entity("BozonStore.Models.SellerShop", b =>
                {
                    b.HasOne("BozonStore.Models.Seller", "Seller")
                        .WithMany("SellersShops")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product.ConstrAndRepair.BathroomEquip.Mixer", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.CommonClass.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId");

                    b.HasOne("BozonStore.Models.ProductModel.BaseProduct", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.ProductModel.Product.ConstrAndRepair.BathroomEquip.Mixer", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Color");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product.ConstrAndRepair.BathroomEquip.Sink", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.BaseProduct", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.ProductModel.Product.ConstrAndRepair.BathroomEquip.Sink", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product.ConstrAndRepair.ElectricyTool.AngleGrinder", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.BaseProduct", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.ProductModel.Product.ConstrAndRepair.ElectricyTool.AngleGrinder", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product.ConstrAndRepair.ElectricyTool.Puncher", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.BaseProduct", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.ProductModel.Product.ConstrAndRepair.ElectricyTool.Puncher", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product.ConstrAndRepair.FinishingMat.WallpaperAndCoatings.WallPanel", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.BaseProduct", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.ProductModel.Product.ConstrAndRepair.FinishingMat.WallpaperAndCoatings.WallPanel", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product.ConstrAndRepair.FinishingMat.WallpaperAndCoatings.Wallpaper", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.BaseProduct", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.ProductModel.Product.ConstrAndRepair.FinishingMat.WallpaperAndCoatings.Wallpaper", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product.Electronics.Audio", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.CommonClass.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId");

                    b.HasOne("BozonStore.Models.ProductModel.BaseProduct", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.ProductModel.Product.Electronics.Audio", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Color");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product.Electronics.Computer", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.CommonClass.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId");

                    b.HasOne("BozonStore.Models.ProductModel.BaseProduct", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.ProductModel.Product.Electronics.Computer", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Color");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product.Electronics.Smartphone", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.CommonClass.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId");

                    b.HasOne("BozonStore.Models.ProductModel.BaseProduct", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.ProductModel.Product.Electronics.Smartphone", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Color");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product.Electronics.Television", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.CommonClass.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId");

                    b.HasOne("BozonStore.Models.ProductModel.BaseProduct", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.ProductModel.Product.Electronics.Television", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Color");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product.HomeAppliances.Fridge", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.CommonClass.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId");

                    b.HasOne("BozonStore.Models.ProductModel.BaseProduct", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.ProductModel.Product.HomeAppliances.Fridge", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Color");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product.HomeAppliances.Stove", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.CommonClass.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId");

                    b.HasOne("BozonStore.Models.ProductModel.BaseProduct", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.ProductModel.Product.HomeAppliances.Stove", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Color");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.Product.HomeAppliances.WashingMachine", b =>
                {
                    b.HasOne("BozonStore.Models.ProductModel.CommonClass.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId");

                    b.HasOne("BozonStore.Models.ProductModel.BaseProduct", null)
                        .WithOne()
                        .HasForeignKey("BozonStore.Models.ProductModel.Product.HomeAppliances.WashingMachine", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Color");
                });

            modelBuilder.Entity("BozonStore.Models.ProductModel.BaseProduct", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("BozonStore.Models.SellerShop", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("BozonStore.Models.Buyer", b =>
                {
                    b.Navigation("Purchases");
                });

            modelBuilder.Entity("BozonStore.Models.Seller", b =>
                {
                    b.Navigation("SellersShops");
                });
#pragma warning restore 612, 618
        }
    }
}
