using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using EvSef.Domain.Entities.AboutUs;
using EvSef.Domain.Entities.Account;
using EvSef.Domain.Entities.BeComeChef;
using EvSef.Domain.Entities.ContactInfo;
using EvSef.Domain.Entities.CorporationFoodOrder;
using EvSef.Domain.Entities.CustomFood;
using EvSef.Domain.Entities.Food;
using EvSef.Domain.Entities.FoodPrice;
using EvSef.Domain.Entities.Instagram;
using EvSef.Domain.Entities.JoinUs;
using EvSef.Domain.Entities.MainSlider;
using EvSef.Domain.Entities.Order;
using EvSef.Domain.Entities.OrderDetails;
using EvSef.Domain.Entities.OurCustomer;
using EvSef.Domain.Entities.OurService;
using EvSef.Domain.Entities.Restaurant;
using EvSef.Domain.Entities.SiteSetting;
using EvSef.Domain.Entities.SocialMedia;
using EvSef.Domain.Entities.UserType;
using EvSef.Domain.Entities.Wallet;
using Microsoft.EntityFrameworkCore;


namespace EvSef.Infra.Data.Context
{
    public class EvSefDbContext : DbContext
    {
        public EvSefDbContext(DbContextOptions<EvSefDbContext> options) : base(options)
        {

        }


        #region Users

        public DbSet<Person> Persons { get; set; }
        public DbSet<Corporation> Corporations { get; set; }
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Client> Clients { get; set; }

        #endregion

        #region ContactInfo

        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<ContactLocation> ContactLocations { get; set; }

        #endregion

        #region Wallet

        public DbSet<Wallet> Wallets { get; set; }

        #endregion

        #region Food

        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<FoodSelectedCategory> FoodSelectedCategories { get; set; }
        public DbSet<WeekDayFood> WeekDayFoods { get; set; }

        #endregion

        #region ChefFood

        public DbSet<ChefFood> ChefFoods { get; set; }

        #endregion

        #region Custom Food

        public DbSet<CustomFood> CustomFoods { get; set; }

        #endregion

        #region Main Sliders

        public DbSet<MainSlider> MainSliders { get; set; }

        #endregion

        #region OurService

        public DbSet<OurService> OurServices { get; set; }

        #endregion

        #region FoodPrice


        public DbSet<ChefFoodPrice> ChefFoodPrices { get; set; }
        public DbSet<PriceType> PriceTypes { get; set; }

        #endregion

        #region OurCustomer

        public DbSet<OurCustomer> OurCustomers { get; set; }


        #endregion

        #region CorporationFoodOrder

        public DbSet<CorporationFoodOrder> CorporationFoodOrders { get; set; }


        #endregion

        #region JoinUs

        public DbSet<JoinUs> JoinUs { get; set; }

        #endregion

        #region BeComeChef

        public DbSet<BeComeChef> BeComeChefs { get; set; }

        #endregion

        #region Restaurant

        public DbSet<Restaurant> Restaurants { get; set; }

        #endregion

        #region About Us

        public DbSet<AboutUs> AboutUs { get; set; }

        #endregion

        #region Social Media 

        public DbSet<SocialMedia> SocialMedia { get; set; }

        #endregion

        #region Instagram

        public DbSet<Instagram> Instagram { get; set; }

        #endregion

        #region SiteSetting

        public DbSet<SiteSetting> SiteSettings { get; set; }

        #endregion

        #region CorporationFood

        public DbSet<CorporationFood> CorporationFoods { get; set; }

        #endregion

        #region Order

        public DbSet<Order> Orders { get; set; }

        #endregion


        #region OrderDetails

        public DbSet<OrderDetails> OrderDetails { get; set; }

        #endregion


        #region Cascade

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<FoodSelectedCategory>((foodSelectedCategory) =>
            {
                foodSelectedCategory
                    .HasOne(x => x.Food)
                    .WithMany(x => x.FoodSelectedCategories)
                    .HasForeignKey(x => x.FoodId);

                foodSelectedCategory
                    .HasOne(x => x.FoodCategory)
                    .WithMany(x => x.FoodSelectedCategories)
                    .HasForeignKey(x => x.FoodCategoryId);

                // Indexes if needed
                foodSelectedCategory.HasIndex(x => x.FoodId);
                foodSelectedCategory.HasIndex(x => x.FoodCategoryId);
            });

            modelBuilder.Entity<ChefFoodPrice>().Property(p => p.ChefFoodsPrice).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<ChefFoodPrice>().Property(p => p.ChefFoodPriceIsDefault).HasColumnType("decimal(18,4)");

  

            // ایجاد ایندکس ترکیبی برای ClientId و OrderNumber
            modelBuilder.Entity<Order>()
                .HasIndex(o => new { o.ClientId, o.OrderNumber });



        }

    }
}

// Or Add      [Column(TypeName = "decimal(18,2)")] to ChefFoodPriceDb for Decimal Properties
    //modelBuilder.Entity<ChefFoodPrice>().Property(p => p.ChefFoodsPrice).HasColumnType("decimal(18,4)");
    //modelBuilder.Entity<ChefFoodPrice>().Property(p => p.ChefFoodPriceIsDefault).HasColumnType("decimal(18,4)");




    //modelBuilder.Entity<Person>()
    //    .Property(s => s.PersonId)
    //    .HasColumnName("PersonId")
    //    .HasDefaultValue(0)
    //    .IsRequired();

    //modelBuilder.Entity<Chef>()
    //    .Property(s => s.ChefId)
    //    .HasColumnName("ChefId")
    //    .HasDefaultValue(0)
    //    .IsRequired();

    //modelBuilder.Entity<Corporation>()
    //    .Property(s => s.CorporationId)
    //    .HasColumnName("CorporationId")
    //    .HasDefaultValue(0)
    //    .IsRequired();

    #region ContactLocation

    //modelBuilder.Entity<ContactLocation>()
    //    .HasData(new ContactLocation()
    //    {

    //        LocationId = 1,
    //        ParentId = null,
    //        StateName = "Karshiaka",
    //    }, new ContactLocation()

    //    {
    //    LocationId =2,
    //    ParentId = 1,
    //    StateName = "Dedbashi",
    //});

    #endregion


    #endregion



 


