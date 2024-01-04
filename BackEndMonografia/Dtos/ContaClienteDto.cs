using Dapper.Contrib.Extensions;

namespace BackEndMonografia.Dtos
{

    [Table("TB_CONTA_CLIENTES")]
    public class ContaClienteDto
    {
        [Key]
        public int NUM_CONTA { get; set; }

        public long ID_CLIENTE { get; set; }

        public int ID_TIPO_CONTA { get; set; }
    }

}
