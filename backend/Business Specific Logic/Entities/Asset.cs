using RepositoryLogic.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessSpecificLogic.EF
{
    public partial class Asset : Document
    {
        [NotMapped]
        public override int id { get { return AssetKey; } }
    }
}
