namespace BusinessSpecificLogic.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cross_Emploee_Asset
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmploeeKey { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AssetKey { get; set; }

        public int? DutyLevelKey { get; set; }

        public virtual Asset Asset { get; set; }

        public virtual cat_DutyLevel cat_DutyLevel { get; set; }

        public virtual Emploee Emploee { get; set; }
    }
}
