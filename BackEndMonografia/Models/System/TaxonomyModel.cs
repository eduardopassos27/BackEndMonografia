using Dapper.Contrib.Extensions;

namespace BackEndMonografia.Models.System
{
    [Table("TaxonomyTable")]
    public class TaxonomyModel
    {
        [Key]
        public int OriginId { get; set; }
        [Key]
        public int TypeId { get; set; }
        [Key]
        public int DescriptionId { get; set; }
        [Key]
        public int AreaId { get; set; }
        public int ResulutionDeadline { get; set; }
        public string UsedFor { get; set; }
    }
}
