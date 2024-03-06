namespace Domain.Entities
{
    public class Entity
    {
        public Guid Id { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}