using Dapper.Contrib.Extensions;

namespace BackEndMonografia.Dtos
{
    [Table("TB_DESCRICOES")]
    public class DescricaoDto
    {
        [Key]
        public int ID_DESC { get; set; }
        [Key]
        public int ID_TIPO { get; set; }

        public string TXT_DESCRICAO { get; set; }
    }
}
