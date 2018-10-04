using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class EventItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public int EventLocationId { get; set; }
        public int EventOccasionId { get; set; }
        public int EventCategoryId { get; set; }

        public virtual EventLocation EventLocation { get; set; }
        public virtual EventOccasion EventOccasion { get; set; }
        public virtual EventCategory EventCategory { get; set; }

    }
}
