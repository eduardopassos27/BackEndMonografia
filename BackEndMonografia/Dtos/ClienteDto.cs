using System;
using System.Text.Json.Serialization;
using Dapper.Contrib.Extensions;
namespace BackEndMonografia.Dtos
{
    [Table("TB_CLIENTES")]
    public class ClienteDto
    {
        [Key]
        [JsonPropertyName("clientId")]
        public long ID_CLIENTE { get; set; }
        [JsonPropertyName("clientName")]

        public string NOME_CLIENTE { get; set; }
        [JsonPropertyName("documento")]

        public string DOCUMENTO { get; set; }
        [JsonPropertyName("segmentoId")]

        public int ID_SEGMENTO { get; set; }
        [JsonPropertyName("address")]

        public int ID_ENDERECO { get; set; }
    }

    public class ClienteCompleteResponseDto : ClienteDto
    {
        public string NM_SEGMENTO { get; set; }
        public string NM_AGENCIA { get; set; }
        public string CIDADE { get; set; }
        public string ESTADO { get; set; }
        public string LOGRADOURO { get; set; }
        public int NUMERO {  get; set; }




    }
}
