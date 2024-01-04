using Dapper.Contrib.Extensions;

namespace BackEndMonografia.Dtos
{
    [Table("TB_CAMPOS_ADICIONAIS")]
    public class CamposAdicionaisDto
    {
        [Key]
        public int ID_CAMPO { get; set; }
        public int ID_ORIGEM { get; set; }
        public int ID_TIPO { get; set; }
        public int ID_DESC { get; set; }
        public string DESC_CAMPO { get; set; }
    }
}
