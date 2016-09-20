namespace BusinessSpecificLogic.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Asset
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Asset()
        {
            cross_Emploee_Asset = new HashSet<cross_Emploee_Asset>();
            cat_Area = new HashSet<cat_Area>();
        }

        [Key]
        public int AssetKey { get; set; }

        [Required]
        [StringLength(70)]
        public string AssetName { get; set; }

        public string Description { get; set; }

        public bool sys_active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cross_Emploee_Asset> cross_Emploee_Asset { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cat_Area> cat_Area { get; set; }
    }
}
