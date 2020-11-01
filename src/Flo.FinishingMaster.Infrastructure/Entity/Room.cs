using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Flo.FinishingMaster.Infrastructure.Entity
{
    public class Room : BaseEntity
    {
        public string Name { get; set; }
        public Guid ApartmentId { get; set; }

        [JsonIgnore]
        public virtual Apartment Apartment { get; set; }
        public virtual List<Wall> Walls { get; set; } = new List<Wall>();
    }
}
