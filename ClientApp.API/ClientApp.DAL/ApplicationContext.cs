using ClientApp.API.ClientApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ClientApp.API.ClientApp.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientContact> ClientContacts { get; set; }
        public DbSet<ClientGroup> ClientGroups { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }
        public DbSet<NotificationSubscriber> NotificationSubscribers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardMetadata> CardsMetadata { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.LogTo(Console.WriteLine);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(ConfigureClient);
            modelBuilder.Entity<Card>(ConfigureCard);
            modelBuilder.Entity<CardMetadata>(ConfigureCardMetadata);
            modelBuilder.Entity<ClientContact>(ConfigureClientContact);
            modelBuilder.Entity<ClientGroup>(ConfigureClientGroup);
            modelBuilder.Entity<ClientType>(ConfigureClientType);
            modelBuilder.Entity<NotificationSubscriber>(ConfigureNotificationSubscriber);
            modelBuilder.Entity<User>(ConfigureUser);
        }

        private void ConfigureClient(EntityTypeBuilder<Client> builder)
        {
            builder.Property(c => c.OrganizationShortName)
                .IsRequired(true)
                .HasColumnType("nvarchar(1024)");
            builder.Property(c => c.OrganizationFullName)
                .IsRequired(true)
                .HasColumnType("nvarchar(2048)");
            builder.Property(c => c.INN)
                .IsRequired(true)
                .HasColumnType("nvarchar(12)");
            builder.Property(c => c.KPP)
                .IsRequired(false)
                .HasColumnType("nvarchar(9)");
            builder.Property(c => c.PostalAddress)
                .IsRequired(true)
                .HasColumnType("nvarchar(500)");
            builder.Property(c => c.FactAddress)
                .IsRequired(true)
                .HasColumnType("nvarchar(500)");
            builder.Property(c => c.LegalAddress)
                .IsRequired(true)
                .HasColumnType("nvarchar(500)");
            builder.Property(c => c.Email)
                .IsRequired(true)
                .HasColumnType("nvarchar(100)");
            builder.Property(c => c.Phone)
                .IsRequired(false)
                .HasColumnType("nvarchar(30)");
            builder.Property(c => c.CreatedDt)
                .IsRequired(true)
                .HasColumnType("datetime");
            builder.Property(c => c.ModifiedDt)
                .IsRequired(true)
                .HasColumnType("datetime");
            builder.Property(c => c.LastViewedDt)
                .IsRequired(true)
                .HasColumnType("datetime");
        }

        private void ConfigureCard(EntityTypeBuilder<Card> builder)
        {
            builder.Property(c => c.Name)
                .IsRequired(true)
                .HasColumnType("nvarchar(100)");
            builder.Property(c => c.MetaDataId)
                .IsRequired(true)
                .HasColumnType("integer");
        }

        private void ConfigureCardMetadata(EntityTypeBuilder<CardMetadata> builder)
        {           
            builder.Property(c => c.Metadata)
                .IsRequired(true)
                .HasColumnType("text");
        }

        private void ConfigureClientContact(EntityTypeBuilder<ClientContact> builder)
        {
            builder.Property(c => c.FirstName)
                .IsRequired(true)
                .HasColumnType("nvarchar(250)");
            builder.Property(c => c.LastName)
                .IsRequired(true)
                .HasColumnType("nvarchar(250)");
            builder.Property(c => c.MiddleName)
                .IsRequired(false)
                .HasColumnType("nvarchar(250)");
            builder.Property(c => c.Post)
                .IsRequired(true)
                .HasColumnType("nvarchar(250)");
            builder.Property(c => c.Email)
                .IsRequired(true)
                .HasColumnType("nvarchar(100)");
            builder.Property(c => c.MobilePhone)
                .IsRequired(false)
                .HasColumnType("nvarchar(30)");
        }

        private void ConfigureClientGroup(EntityTypeBuilder<ClientGroup> builder)
        {
            builder.Property(c => c.GroupName)
                .IsRequired(true)
                .HasColumnType("nvarchar(250)");
            builder.Property(c => c.Description)
                .IsRequired(false)
                .HasColumnType("nvarchar(2048)");
        }

        private void ConfigureClientType(EntityTypeBuilder<ClientType> builder)
        {
            builder.Property(c => c.TypeName)
                .IsRequired(true)
                .HasColumnType("nvarchar(2)");
            builder.Property(c => c.Description)
                .IsRequired(false)
                .HasColumnType("nvarchar(2048)");
        }

        private void ConfigureNotificationSubscriber(EntityTypeBuilder<NotificationSubscriber> builder)
        {
            builder.Property(c => c.IsActive)
                .IsRequired(true)
                .HasColumnType("integer");
        }

        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.Property(c => c.FirstName)
                 .IsRequired(true)
                 .HasColumnType("nvarchar(250)");
            builder.Property(c => c.LastName)
                .IsRequired(true)
                .HasColumnType("nvarchar(250)");
            builder.Property(c => c.MiddleName)
                .IsRequired(false)
                .HasColumnType("nvarchar(250)");
            builder.Property(c => c.Post)
                .IsRequired(true)
                .HasColumnType("nvarchar(250)");
            builder.Property(c => c.Email)
                .IsRequired(true)
                .HasColumnType("nvarchar(100)");
            builder.Property(c => c.MobilePhone)
                .IsRequired(false)
                .HasColumnType("nvarchar(30)");
            builder.Property(c => c.InternalPhone)
                .IsRequired(false)
                .HasColumnType("nvarchar(4)");
        }
    }
}
