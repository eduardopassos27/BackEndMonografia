using Dapper.Contrib.Extensions;

namespace BackEndMonografia.Dtos
{
    [Table("TB_TAXONOMIA")]
    public class TaxonomiaDto
    {
        [Key]
        public int ID_ORIGEM { get; set; }

        [Key]
        public int ID_TIPO { get; set; }

        [Key]
        public int ID_DESC { get; set; }

        public int? ID_AREA { get; set; }

        public int? RESOLUTION_DEADLINE { get; set; }

        public string USED_FOR { get; set; }
    }
}
