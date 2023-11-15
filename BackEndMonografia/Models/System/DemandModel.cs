namespace BackEndMonografia.Models.System
{
    public class DemandModel
    {
        public long DemandId { get; set; }
        public int TypeId { get; set; }
        public int DescriptionId { get; set; }
        public int AreaId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StatusId { get; set; }
        public string SystemUser { get; set; }
        public int ResulutionDeadline { get; set; }
        public string? Solution { get; set; }
        public string? OpeningComment { get; set; }
        public string? FinalComment {get; set;}
        public int ClientId { get; set; }
    }
}
