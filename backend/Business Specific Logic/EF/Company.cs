namespace BusinessSpecificLogic.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Company")]
    public partial class Company
    {
        [Key]
        public int CompanyKey { get; set; }

        public int LocationKey { get; set; }

        [Required]
        [StringLength(200)]
        public string CompanyName { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public string Address { get; set; }

        [StringLength(50)]
        public string PhoneOne { get; set; }

        [StringLength(50)]
        public string PhoneTwo { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public bool sys_active { get; set; }

        public virtual cat_Location cat_Location { get; set; }
    }
}
