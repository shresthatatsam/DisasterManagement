namespace DMS.Data.Dtos
{
    public class DisasterDTO
    {
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Severity { get; set; }
        public DateTime Date_Occurred { get; set; }
    }
}
