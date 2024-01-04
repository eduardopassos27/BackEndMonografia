using Dapper.Contrib.Extensions;
using System.Text.Json.Serialization;

namespace BackEndMonografia.Dtos
{
    [Table("TB_TIPOS")]
    public class TipoDto
    {
        [Key]
        [JsonPropertyName("typeId")]
        public int ID_TIPO { get; set; }
        [JsonPropertyName("typeDescription")]
        public string TXT_TIPO { get; set; }
    }
}
