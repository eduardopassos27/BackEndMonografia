using Dapper.Contrib.Extensions;

namespace BackEndMonografia.Dtos
{
    [Table("TB_DEMANDAS")]
    public class DemandaDto
    {
        [Key]
        public long ID_DEMANDA { get; set; }

        public int ID_TIPO { get; set; }

        public int ID_DESC { get; set; }

        public int? ID_AREA { get; set; }

        public DateTime DT_INICIO { get; set; }

        public DateTime? DT_FIM { get; set; }

        public int ID_STATUS { get; set; }

        public int? PRAZO_RESOLUCAO { get; set; }

        public string? SOLUCAO { get; set; }

        public string COMENTARIO_ABERTURA { get; set; }

        public string? COMENTARIO_FINAL { get; set; }

        public long? ID_CLIENTE { get; set; }

        public int ID_ORIGEM { get; set; }
    }
}
