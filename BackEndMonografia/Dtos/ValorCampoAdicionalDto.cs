using Dapper.Contrib.Extensions;

namespace BackEndMonografia.Dtos
{
    [Table("TB_VALOR_CAMPOS_ADICIONAIS")]
    public class ValorCampoAdicionalDto
    {
        [Key]
        public int ID_VALOR_CAMPO { get; set; }

        public long ID_DEMANDA { get; set; }

        public int ID_CAMPO { get; set; }

        public string TXT_VALOR { get; set; }
    }
}
