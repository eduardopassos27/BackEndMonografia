using Dapper.Contrib.Extensions;

namespace BackEndMonografia.Models.System
{
    [Table("OriginTable")]
    public class OriginModel
    {
        [Key]
        public int OriginId { get; set; }
        public string OriginDescription { get; set; }
    }
}
