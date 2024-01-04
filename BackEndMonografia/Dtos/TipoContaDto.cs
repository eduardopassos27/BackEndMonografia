using Dapper.Contrib.Extensions;

namespace BackEndMonografia.Dtos
{
    [Table("TB_TIPO_CONTAS")]
    public class TipoContaDto
    {
        [Key]
        public int ID_TIPO_CONTA { get; set; }

        public string DESC_TIPO_CONTA { get; set; }
    }
}
