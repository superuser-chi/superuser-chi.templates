using System;
using System.ComponentModel.DataAnnotations.Schema;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Metadata;
using Persistence.EntityConfig;

namespace Persistence
{
    public partial class CanteenSystemContext : IdentityDbContext<User>
    {
        public CanteenSystemContext(DbContextOptions<CanteenSystemContext> options) : base(options) { }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CustomerType> CustomerTypes { get; set; }
        public virtual DbSet<DepartmentalAccount> DepartmentalAccounts { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<IndividualAccount> IndividualAccounts { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Meeting> Meetings { get; set; }
        public virtual DbSet<MeetingParticipant> MeetingParticipants { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<MenuItemPrice> MenuItemPrices { get; set; }
        public virtual DbSet<MenuItemAvailability> MenuItemAvailabilities { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OnlineOrder> OnlineOrders { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<PortionType> PortionTypes { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<OfficeAddress> OfficeAddresses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new System.InvalidOperationException("Cannot connect to db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Warnig: keys of Identity tables are mapped in OnModelCreating method of IdentityDbContext 
            // and if this method is not called there will be an error
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AccountConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new DepartmentConfig());
            modelBuilder.ApplyConfiguration(new LocationConfig());
            modelBuilder.ApplyConfiguration(new MeetingConfig());
            modelBuilder.ApplyConfiguration(new MeetingParticipantConfig());
            modelBuilder.ApplyConfiguration(new MenuItemAvailabilityConfig());
            modelBuilder.ApplyConfiguration(new MenuItemConfig());
            modelBuilder.ApplyConfiguration(new MenuItemPriceConfig());
            modelBuilder.ApplyConfiguration(new OfficeAddressConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new OrderDetailsConfig());
            modelBuilder.ApplyConfiguration(new PaymentConfig());
            modelBuilder.ApplyConfiguration(new PaymentTypeConfig());
            modelBuilder.ApplyConfiguration(new SubCategoryConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
        }
    }
}