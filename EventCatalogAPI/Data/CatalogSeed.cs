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
               await context.SaveChangesAsync();
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
                new EventLocation {Location="East of Seattle"},
                new EventLocation {Location="West of Seattle"},
                new EventLocation {Location="North of Seattle"},
                new EventLocation {Location="South of Seattle"}
            };
        }

        private static IEnumerable<EventCategory> GetPreconfiguredEventCategories()
        {
            return new List<EventCategory>()
            {
                new EventCategory {Category="indoors"},
                new EventCategory {Category="outdoors"}
               
            };
        }

        private static IEnumerable<EventItem> GetPreconfiguredEventItems()
        {
            return new List<EventItem>()
            {
                new EventItem() { EventOccasionId=1,EventLocationId=3,EventCategoryId=2, Description = "45Acres of pumpkin Patches, open Daily from 10am-6pm", Name = "The Farm at Swan's Trail", Price = 25M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                new EventItem() { EventOccasionId=1,EventLocationId=1,EventCategoryId=2, Description = "Pumpkin Patches,Train ride, pet animals, pony rides, open Daily from 10am-5pm", Name = "Fox Hollow Farm", Price = 10M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                new EventItem() { EventOccasionId=1,EventLocationId=1,EventCategoryId=2, Description = "Train ride, antique cars, pet animals, hay maze, all perfect for toddlers, open Daily from 10am-6pm", Name = "Remlinger Farms", Price = 18.75M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                new EventItem() { EventOccasionId=1,EventLocationId=2,EventCategoryId=1, Description = "With 100 retailers handing out candy, open on Halloween day from 3am-6pm", Name = "Trick-or-Treat in Fremont", Price = 0M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                new EventItem() { EventOccasionId=2,EventLocationId=2,EventCategoryId=1, Description = "Grand Finale Night on Dec 23rd 2018 ,7pm-10:05pm", Name = "The 2018 Christmas Ship Festival", Price = 48M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                new EventItem() { EventOccasionId=2,EventLocationId=1,EventCategoryId=2, Description = "Half a million sparkling lights at Bellevue Botanical Garden, open Nov 24th-Dec 30th 2018 from 4:30pm-9:00pm", Name = "Garden d'Lights", Price = 5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                new EventItem() { EventOccasionId=2,EventLocationId=1,EventCategoryId=2, Description = "Featuring A Nightly parade, open Nov 23rd - Dec 24th 2018 from 10am-6pm", Name = "Snowflake Lane", Price = 0M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                new EventItem() { EventOccasionId=3,EventLocationId=3,EventCategoryId=1, Description = "New Year celebration with Live Music,dance and drinks, on Dec 31st 2018 from 10pm-12am", Name = "Fife at Emerald Casino", Price = 20M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                new EventItem() { EventOccasionId=3,EventLocationId=4,EventCategoryId=1, Description = "Social, appetizers,dinner and dancing till dawn", Name = "Shoreline Elks Club", Price = 25M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                new EventItem() { EventOccasionId=3,EventLocationId=2,EventCategoryId=2, Description = "Sway Band and Fireworks on Dec 31st 2018 from 8pm-12am", Name = "Seattle Center", Price = 0M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },






            };
        }




    }
}
