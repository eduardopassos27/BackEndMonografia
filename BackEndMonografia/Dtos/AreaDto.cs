using Dapper.Contrib.Extensions;
using System.Text.Json.Serialization;

namespace BackEndMonografia.Models.System
{
    [Table("TB_AREAS")]
    public class AreaDto
    {
        [Key]
        [JsonPropertyName("areaId")]
        public int ID_AREA { get; set; }
        [JsonPropertyName("areaName")]
        public string NM_AREA { get; set; }

    }
}
