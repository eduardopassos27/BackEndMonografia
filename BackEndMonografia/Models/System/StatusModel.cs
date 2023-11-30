using Dapper.Contrib.Extensions;

namespace BackEndMonografia.Models.System
{
    [Table("StatusTable")]
    public class StatusModel
    {
        [Key]
        public int StatusId { get; set; }
        public string StatusDescription { get; set; }
    }
}
