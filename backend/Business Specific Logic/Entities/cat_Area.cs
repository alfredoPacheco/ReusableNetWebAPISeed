using RepositoryLogic.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessSpecificLogic.EF
{
    public partial class cat_Area : Entity
    {
        [NotMapped]
        public override int id { get { return AreaKey; } }
    }
}
