using Dapper.Contrib.Extensions;

namespace BackEndMonografia.Dtos
{
    [Table("TB_TAXONOMIAS")]
    public class TaxonomiaDto
    {
        [Key]
        public int ID_ORIGEM { get; set; }

        [Key]
        public int ID_TIPO { get; set; }

        [Key]
        public int ID_DESC { get; set; }

        public int? ID_AREA { get; set; }

        public int? PRAZO_RESOLUCAO { get; set; }

        public string USADO_PARA { get; set; }
    }
}
