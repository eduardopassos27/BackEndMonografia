using Dapper.Contrib.Extensions;
using System.Text.Json.Serialization;

namespace BackEndMonografia.Dtos
{
    [Table("TB_STATUS")]
    public class StatusDto
    {
        [Key]
        [JsonPropertyName("StatusId")]
        public int ID_STATUS { get; set; }
        [JsonPropertyName("StatusDescription")]
        public string NM_STATUS { get; set; }
    }
}
