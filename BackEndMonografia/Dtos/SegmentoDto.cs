using Dapper.Contrib.Extensions;
using System.Text.Json.Serialization;

namespace BackEndMonografia.Dtos
{
    [Table("TB_SEGMENTOS")]
    public class SegmentoDto
    {
        [Key]
        [JsonPropertyName("id")]
        public int ID_SEGMENTO { get; set; }
        [JsonPropertyName("descricao")]
        public string NM_SEGMENTO { get; set; }
    }
}
