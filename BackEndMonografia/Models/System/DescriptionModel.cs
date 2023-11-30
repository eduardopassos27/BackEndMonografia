using Dapper.Contrib.Extensions;

namespace BackEndMonografia.Models.System
{
    [Table("DescriptionTable")]
    public class DescriptionModel
    {
        public int TypeId { get; set; }
        [Key]
        public int DescriptionId { get; set; }
        public string DescriptionText { get; set; }
    }
}
