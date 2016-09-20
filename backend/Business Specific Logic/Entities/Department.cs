using RepositoryLogic.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessSpecificLogic.EF
{
    public partial class Department : Entity
    {
        [NotMapped]
        public override int id { get { return DepartmentKey; } }
    }
}
