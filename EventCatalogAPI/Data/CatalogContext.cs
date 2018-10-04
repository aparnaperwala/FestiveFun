using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class CatalogContext:DbContext
    {
    public CatalogContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<EventOccasion> EventOccasions { get; set; }
        public DbSet<EventLocation> EventLocations { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventItem> EventItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventCategory>(ConfigureEventCategory);
            modelBuilder.Entity<EventLocation>(ConfigureEventLocation);
            modelBuilder.Entity<EventOccasion>(ConfigureEventOccasion);
            modelBuilder.Entity<EventItem>(ConfigureEventItem);
        }

        private void ConfigureEventOccasion(EntityTypeBuilder<EventOccasion> builder)
        {
            builder.ToTable("EventOcassion");
            builder.Property(c => c.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("event_occasion_hilo");
            builder.Property(c => c.Occasion)
            .IsRequired()
            .HasMaxLength(200);
        }

        private void ConfigureEventLocation(EntityTypeBuilder<EventLocation> builder)
        {
            builder.ToTable("EventLocation");
            builder.Property(c => c.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("event_occasion_hilo");
            builder.Property(c => c.Location)
            .IsRequired()
            .HasMaxLength(200);
        }


        private void ConfigureEventCategory(EntityTypeBuilder<EventCategory> builder)
        {
            builder.ToTable("EventCategory");
            builder.Property(c => c.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("event_occasion_hilo");
            builder.Property(c => c.Category)
            .IsRequired()
            .HasMaxLength(200);
        }

        private void ConfigureEventItem(EntityTypeBuilder<EventItem> builder)
        {
            builder.ToTable("EventItem");
            builder.Property(c => c.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("event_item_hilo");
            builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);
            builder.Property(c => c.Price)
                .IsRequired();

            builder.HasOne(c => c.EventLocation)
                .WithMany()
                .HasForeignKey(c => c.EventLocationId);

            builder.HasOne(c => c.EventOccasion)
                            .WithMany()
                            .HasForeignKey(c => c.EventOccasionId);

            builder.HasOne(c => c.EventCategory)
                .WithMany()
                .HasForeignKey(c => c.EventCategoryId);

        }

    }


}
