using RepositoryLogic.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessSpecificLogic.EF
{
    public partial class cat_Location : Entity
    {
        [NotMapped]
        public override int id { get { return LocationKey; } }
    }
}
