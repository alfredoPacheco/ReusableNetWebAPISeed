namespace BusinessSpecificLogic.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Department")]
    public partial class Department
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Department()
        {
            Emploees = new HashSet<Emploee>();
        }

        [Key]
        public int DepartmentKey { get; set; }

        public int LocationKey { get; set; }

        [Required]
        [StringLength(150)]
        public string Deparment { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public virtual cat_Location cat_Location { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emploee> Emploees { get; set; }
    }
}
