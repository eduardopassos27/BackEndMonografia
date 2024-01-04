using Dapper.Contrib.Extensions;

namespace BackEndMonografia.Dtos
{
    [Table("TB_ENDERECO")]
    public class EnderecoDto
    {
        [Key]
        public int ID_ENDERECO { get; set; }

        public string LOGRADOURO { get; set; }

        public string NUMERO { get; set; }

        public string BAIRRO { get; set; }

        public string CIDADE { get; set; }

        public string ESTADO { get; set; }

        public string CEP { get; set; }
    }
}
