using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class CatalogSeed
    {
        public static async Task SeedAsync(CatalogContext context)
        {
            context.Database.Migrate();
            if(!context.EventOccasions.Any())
            {
                context.EventOccasions.AddRange(GetPreconfiguredEventOccasions());
                context.SaveChanges();
            }

            context.Database.Migrate();
            if (!context.EventLocations.Any())
            {
                context.EventLocations.AddRange(GetPreconfiguredEventLocations());
                context.SaveChanges();
            }

            context.Database.Migrate();
            if (!context.EventCategories.Any())
            {
                context.EventCategories.AddRange(GetPreconfiguredEventCategories());
                context.SaveChanges();
            }

            context.Database.Migrate();
            if (!context.EventItems.Any())
            {
                context.EventItems.AddRange(GetPreconfiguredEventItems());
                context.SaveChanges();
            }
        }

private static IEnumerable<EventOccasion> GetPreconfiguredEventOccasions()
        {
            return new List<EventOccasion>()
            {
                new EventOccasion {Occasion="Halloween"},
                new EventOccasion {Occasion="Christmas"},
                new EventOccasion {Occasion="NewYear"}
            };
        }


        private static IEnumerable<EventLocation> GetPreconfiguredEventLocations()
        {
            return new List<EventLocation>()
            {
                new EventLocation {Location="Bothell"},
                new EventLocation {Location="Bellevue"},
                new EventLocation {Location="Seattle"}
            };
        }

        private static IEnumerable<EventCategory> GetPreconfiguredEventCategories()
        {
            return new List<EventCategory>()
            {
                new EventCategory {Category="indoors"},
                new EventCategory {Category="outdoor"}
               
            };
        }

        private static IEnumerable<EventItem> GetPreconfiguredEventItems()
        {
            return new List<EventItem>()
            {
                new EventItem() { EventOccasionId=2,EventLocationId=3,EventCategoryId=3, Description = "Shoes for next century", Name = "World Star", Price = 199.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },
            };
        }




    }
}
