using System;

namespace Flo.FinishingMaster.Infrastructure.Entity
{
    public class Material
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public EMaterialType MaterialType { get; set; }
        public string Url { get; set; }
        public string UnitName { get; set; }
        public decimal VolumePerSquare { get; set; }
        public decimal UnitVolume { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
