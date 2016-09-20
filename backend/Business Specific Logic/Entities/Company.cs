using RepositoryLogic.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessSpecificLogic.EF
{
    public partial class Company : Document
    {
        [NotMapped]
        public override int id { get { return CompanyKey; } }
    }
}
