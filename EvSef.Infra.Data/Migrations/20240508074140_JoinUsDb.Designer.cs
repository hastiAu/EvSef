﻿// <auto-generated />
using System;
using EvSef.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EvSef.Infra.Data.Migrations
{
    [DbContext(typeof(EvSefDbContext))]
    [Migration("20240508074140_JoinUsDb")]
    partial class JoinUsDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EvSef.Domain.Entities.Account.Chef", b =>
                {
                    b.Property<int>("ChefId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChefId"));

                    b.Property<string>("ChefAvatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ChefRequestState")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MealsNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserState")
                        .HasColumnType("int");

                    b.HasKey("ChefId");

                    b.ToTable("Chefs");
                });

            modelBuilder.Entity("EvSef.Domain.Entities.Account.Corporation", b =>
                {
                    b.Property<int>("CorporationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CorporationId"));

                    b.Property<string>("CorporationAvatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorporationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CorporationRequestState")
                        .HasColumnType("int");

                    b.Property<int>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StaffNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UserState")
                        .HasColumnType("int");

                    b.HasKey("CorporationId");

                    b.ToTable("Corporations");
                });

            modelBuilder.Entity("EvSef.Domain.Entities.Account.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserState")
                        .HasColumnType("int");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("EvSef.Domain.Entities.ContactInfo.ContactInfo", b =>
                {
                    b.Property<int>("ContactInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactInfoId"));

                    b.Property<string>("ContactInfoAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactInfoZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RelatedId")
                        .HasColumnType("int");

                    b.Property<int>("RelatedType")
                        .HasColumnType("int");

                    b.HasKey("ContactInfoId");

                    b.ToTable("ContactInfos");
                });

            modelBuilder.Entity("EvSef.Domain.Entities.ContactInfo.ContactLocation", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"));

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.HasIndex("ParentId");

                    b.ToTable("ContactLocations");
                });

            modelBuilder.Entity("EvSef.Domain.Entities.CorporationFoodOrder.CorporationFoodOrder", b =>
                {
                    b.Property<int>("CorporationFoodOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CorporationFoodOrderId"));

                    b.Property<string>("CorporationFoodOrderDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorporationFoodOrderImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorporationFoodOrderTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CorporationFoodOrderId");

                    b.ToTable("CorporationFoodOrders");
                });

            modelBuilder.Entity("EvSef.Domain.Entities.Food.ChefFood", b =>
                {
                    b.Property<int>("ChefFoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChefFoodId"));

                    b.Property<float>("ChefFoodLimitCount")
                        .HasColumnType("real");

                    b.Property<int>("ChefId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ChefFoodId");

                    b.HasIndex("ChefId");

                    b.HasIndex("FoodId");

                    b.ToTable("ChefFoods");
                });

            modelBuilder.Entity("EvSef.Domain.Entities.Food.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodId"));

                    b.Property<int>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<string>("FoodDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ImageFood")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.HasKey("FoodId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("EvSef.Domain.Entities.Food.FoodCategory", b =>
                {
                    b.Property<int>("FoodCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodCategoryId"));

                    b.Property<int>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<int?>("FoodCategoryParentId")
                        .HasColumnType("int");

                    b.Property<string>("FoodCategoryTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.HasKey("FoodCategoryId");

                    b.ToTable("FoodCategories");
                });

            modelBuilder.Entity("EvSef.Domain.Entities.Food.FoodSelectedCategory", b =>
                {
                    b.Property<int>("FoodSelectedCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodSelectedCategoryId"));

                    b.Property<int?>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<int>("FoodCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.HasKey("FoodSelectedCategoryId");

                    b.HasIndex("FoodCategoryId");

                    b.HasIndex("FoodId");

                    b.ToTable("FoodSelectedCategories");
                });

            modelBuilder.Entity("EvSef.Domain.Entities.Food.WeekdayFood", b =>
                {
                    b.Property<int>("WeekdayFoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WeekdayFoodId"));

                    b.Property<int>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<int>("FoodCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("WeekDayFromDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("WeekDayToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("WeekdayFoodId");

                    b.HasIndex("FoodCategoryId");

                    b.HasIndex("FoodId");

                    b.ToTable("WeekdayFoods");
                });

            modelBuilder.Entity("EvSef.Domain.Entities.FoodPrice.ChefFoodPrice", b =>
                {
                    b.Property<int>("ChefFoodPriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChefFoodPriceId"));

                    b.Property<int>("ChefFoodId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ChefFoodPriceFromDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ChefFoodPriceIsDefault")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("ChefFoodPriceToDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ChefFoodsPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<int>("PriceTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ChefFoodPriceId");

                    b.HasIndex("ChefFoodId");

                    b.HasIndex("PriceTypeId");

                    b.ToTable("ChefFoodPrices");
                });

            modelBuilder.Entity("EvSef.Domain.Entities.FoodPrice.PriceType", b =>
                {
                    b.Property<int>("PriceTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PriceTypeId"));

                    b.Property<int>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<string>("PriceTypeCurrency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PriceTypeIsDefault")
                        .HasColumnType("bit");

                    b.Property<string>("PriceTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PriceTypeId");

                    b.ToTable("PriceTypes");
                });

            modelBuilder.Entity("EvSef.Domain.Entities.JoinUs.JoinUs", b =>
                {
                    b.Property<int>("JoinUsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JoinUsId"));

                    b.Property<int>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("JoinUsDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JoinUsImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JoinUsTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.HasKey("JoinUsId");

                    b.ToTable("JoinUs");
                });

            modelBuilder.Entity("EvSef.Domain.Entities.OurCustomer.OurCustomer", b =>
                {
                    b.Property<int>("OurCustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OurCustomerId"));

                    b.Property<int>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<string>("CustomerImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("OurCustomerDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OurCustomerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OurCustomerId");

                    b.ToTable("OurCustomers");
                });

            modelBuilder.Entity("EvSef.Domain.Entities.SiteSetting.SiteSetting", b =>
                {
                    b.Property<int>("SiteSettingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SiteSettingId"));

                    b.Property<string>("AboutUs")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BeChefDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BeChefImage")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("BeChefTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorporationFoodDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorporationFoodTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorporationFormTitle2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomFoodDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomFoodTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DietFoodDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DietFoodTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodMenu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HowOrderCorporationFood")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JoinChefTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderFormTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OurChef")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OurService")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonFormTitle2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReasonChefTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteCopyRight")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SiteCustomerPhone")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SiteEmail")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("SiteLogo")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("SiteName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SitePhone")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SiteUrl")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("SloganTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SiteSettingId");

                    b.ToTable("SiteSettings");
                });

            modelBuilder.Entity("EvSef.Domain.Entities.UserType.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<int>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RelatedId")
                        .HasColumnType("int");

                    b.Property<int>("RelatedType")
                        .HasColumnType("int");

                    b.Property<int>("UserState")
                        .HasColumnType("int");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("EvSef.Domain.Entities.ContactInfo.ContactLocation", b =>
                {
                    b.HasOne("EvSef.Domain.Entities.ContactInfo.ContactLocation", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("EvSef.Domain.Entities.Food.ChefFood", b =>
                {
                    b.HasOne("EvSef.Domain.Entities.Account.Chef", "Chef")
                        .WithMany("ChefFood")
                        .HasForeignKey("ChefId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EvSef.Domain.Entities.Food.Food", "Food")
                        .WithMany("ChefFood")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Chef");

                    b.Navigation("Food");
                });

            modelBuilder.Entity("EvSef.Domain.Entities.Food.FoodSelectedCategory", b =>
                {
                    b.HasOne("EvSef.Domain.Entities.Food.FoodCategory", "FoodCategory")
                        .WithMany("FoodSelectedCategories")
                        .HasForeignKey("FoodCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EvSef.Domain.Entities.Food.Food", "Food")
                        .WithMany("FoodSelectedCategories")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("FoodCategory");
                });

            modelBuilder.Entity("EvSef.Domain.Entities.Food.WeekdayFood", b =>
                {
                    b.HasOne("EvSef.Domain.Entities.Food.FoodCategory", null)
                        .WithMany("WeekdayFoods")
                        .HasForeignKey("FoodCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EvSef.Domain.Entities.Food.Food", null)
                        .WithMany("WeekdayFoods")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("EvSef.Domain.Entities.FoodPrice.ChefFoodPrice", b =>
                {
                    b.HasOne("EvSef.Domain.Entities.Food.ChefFood", "ChefFood")
                        .WithMany("ChefFoodPrices")
                        .HasForeignKey("ChefFoodId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EvSef.Domain.Entities.FoodPrice.PriceType", "PriceType")
                        .WithMany("ChefFoodPrices")
                        .HasForeignKey("PriceTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ChefFood");

                    b.Navigation("PriceType");
                });

            modelBuilder.Entity("EvSef.Domain.Entities.Account.Chef", b =>
                {
                    b.Navigation("ChefFood");
                });

            modelBuilder.Entity("EvSef.Domain.Entities.Food.ChefFood", b =>
                {
                    b.Navigation("ChefFoodPrices");
                });

            modelBuilder.Entity("EvSef.Domain.Entities.Food.Food", b =>
                {
                    b.Navigation("ChefFood");

                    b.Navigation("FoodSelectedCategories");

                    b.Navigation("WeekdayFoods");
                });

            modelBuilder.Entity("EvSef.Domain.Entities.Food.FoodCategory", b =>
                {
                    b.Navigation("FoodSelectedCategories");

                    b.Navigation("WeekdayFoods");
                });

            modelBuilder.Entity("EvSef.Domain.Entities.FoodPrice.PriceType", b =>
                {
                    b.Navigation("ChefFoodPrices");
                });
#pragma warning restore 612, 618
        }
    }
}
