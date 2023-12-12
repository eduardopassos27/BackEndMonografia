
using System.ComponentModel.DataAnnotations;

namespace BackEndMonografia.Models.System
{
    public class DescriptionModel
    {
        public int TypeId { get; set; }
        public string? TypeDescription { get; set; }
        public int DescriptionId { get; set; }
        public string DescriptionText { get; set; }
    }
}
