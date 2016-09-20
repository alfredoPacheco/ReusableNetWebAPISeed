using RepositoryLogic.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessSpecificLogic.EF
{
    public partial class Emploee : Entity
    {
        [NotMapped]
        public override int id { get { return EmploeeKey; } }
    }
}
