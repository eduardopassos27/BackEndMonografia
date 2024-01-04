using Dapper.Contrib.Extensions;

namespace BackEndMonografia.Models
{
    [Table("SegmentTable")]
    public class SegmentModel
    {
        [Key]
        public int id { get; set; }

        public string descricao { get; set; }
    }
}
