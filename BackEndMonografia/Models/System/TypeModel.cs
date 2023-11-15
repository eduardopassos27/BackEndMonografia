using Dapper.Contrib.Extensions;

namespace BackEndMonografia.Models.System
{
    [Table("TypeTable")]
    public class TypeModel
    {
        [Key]
        public int TypeId { get; set; }
        public string TypeDescription { get; set; }

    }
}
