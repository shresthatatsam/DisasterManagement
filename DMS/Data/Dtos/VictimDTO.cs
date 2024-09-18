namespace DMS.Data.Dtos
{
    public class VictimDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public bool Status { get; set; }
        public string UserId { get; set; }

        public virtual ICollection<DisasterDTO> Disasters { get; set; }
    }
}
