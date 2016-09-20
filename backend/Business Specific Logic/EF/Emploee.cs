namespace BusinessSpecificLogic.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Emploee")]
    public partial class Emploee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Emploee()
        {
            cross_Emploee_Asset = new HashSet<cross_Emploee_Asset>();
            Emploee1 = new HashSet<Emploee>();
        }

        [Key]
        public int EmploeeKey { get; set; }

        public int? DirectBossKey { get; set; }

        public int DepartmentKey { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(200)]
        public string EmailTwo { get; set; }

        [StringLength(50)]
        public string PhoneOne { get; set; }

        [StringLength(50)]
        public string PhoneTwo { get; set; }

        [StringLength(50)]
        public string PhoneThree { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cross_Emploee_Asset> cross_Emploee_Asset { get; set; }

        public virtual Department Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emploee> Emploee1 { get; set; }

        public virtual Emploee Emploee2 { get; set; }
    }
}
