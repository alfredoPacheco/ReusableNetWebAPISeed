namespace BusinessSpecificLogic.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cat_DutyLevel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cat_DutyLevel()
        {
            cross_Emploee_Asset = new HashSet<cross_Emploee_Asset>();
        }

        [Key]
        public int DutyLevelKey { get; set; }

        [StringLength(70)]
        public string DutyLevel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cross_Emploee_Asset> cross_Emploee_Asset { get; set; }
    }
}
