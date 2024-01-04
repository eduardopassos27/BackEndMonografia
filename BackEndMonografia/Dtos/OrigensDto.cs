using Dapper.Contrib.Extensions;
using System.Text.Json.Serialization;
namespace BackEndMonografia.Dtos
{

    [Table("TB_ORIGENS")]
    public class OrigemDto
    {
        [Key]
        [JsonPropertyName("originId")]
        public int ID_ORIGEM { get; set; }
        [JsonPropertyName("originDescription")]
        public string NM_ORIGEM { get; set; }
    }

}
