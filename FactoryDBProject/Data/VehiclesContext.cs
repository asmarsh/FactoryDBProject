using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FactoryDBProject.Data
{
    public partial class VehiclesContext : DbContext
    {
        public VehiclesContext()
            : base("name=Vehicles")
        {
        }

        public virtual DbSet<VHT001_VEHICLE> VHT001_VEHICLE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VHT001_VEHICLE>()
     .Property(e => e.VehicleId)
     .IsUnicode(false);

            modelBuilder.Entity<VHT001_VEHICLE>()
                .Property(e => e.VehicleColor)
                .IsUnicode(false);
        }
    }
}