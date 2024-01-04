using Dapper.Contrib.Extensions;

namespace BackEndMonografia.Models
{
    [Table("ClientTable")]
    public class ClientModel
    {
        [Key]
        public long ClientId { get; set; }
        public string ClientName { get; set; }
        public int AccountNumber { get; set; }
        public string Address { get; set; }
        public string Documento { get; set; }
        public string SegmentoId { get; set; }

    }
}
