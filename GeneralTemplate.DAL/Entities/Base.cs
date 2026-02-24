namespace GeneralTemplate.DAL.Entities
{
    public class Base
    {
        public int Id { get; private set; }
        public DateTime CreatedOn { get; private set; } = DateTime.Now;
        public DateTime? UpdatedOn { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public string? CreatedBy { get; private set; }
        public string? UpdatedBy { get; private set; }
        public string? DeletedBy { get; private set; }
        public bool IsDeleted { get; private set; }
    }
}
