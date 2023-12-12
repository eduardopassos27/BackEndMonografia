using Dapper.Contrib.Extensions;
using System.Globalization;

namespace BackEndMonografia.Models.System
{
    [Table("TaxonomyTable")]
    public class TaxonomyModel
    {
        public int OriginId { get; set; }
        public string? OriginDescription { get; set; }
        public int TypeId { get; set; }
        public string? TypeDescription { get; set; }
        public int DescriptionId { get; set; }
        public string? DescriptionText { get; set; }
        public int AreaId { get; set; }
        public string? AreaName { get; set; }
        public int ResulutionDeadline { get; set; }
        public string UsedFor { get; set; }
    }
}
