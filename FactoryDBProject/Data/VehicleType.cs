namespace FactoryDBProject.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VehicleType")]
    public partial class VehicleType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VehicleType()
        {
            VHT001_VEHICLE = new HashSet<VHT001_VEHICLE>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VehicleTypeId { get; set; }

        [StringLength(255)]
        public string VehicleTypeName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VHT001_VEHICLE> VHT001_VEHICLE { get; set; }
    }
}
