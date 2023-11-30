using Dapper.Contrib.Extensions;

namespace BackEndMonografia.Models.System
{
    [Table("AreaTable")]
    public class AreaModel
    {
        [Key]
        public int AreaId { get; set; }
        public string AreaName { get; set; }

    }
}
