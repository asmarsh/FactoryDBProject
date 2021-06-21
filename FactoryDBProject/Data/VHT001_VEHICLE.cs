namespace FactoryDBProject.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VHT001_VEHICLE
    {
        [Key]
        public int VehicleNo { get; set; }

        public byte VehicleTypeCode { get; set; }

        [StringLength(50)]
        public string VehicleId { get; set; }

        [Required]
        [StringLength(15)]
        public string VehicleColor { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? VehicleAddDateTime { get; set; }
    }
}
