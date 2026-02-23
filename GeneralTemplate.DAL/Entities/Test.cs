namespace GeneralTemplate.DAL.Entities
{
    public class Test
    {
        public Test(string name, decimal salary, string createToUser)
        {
            Name = name;
            Salary = salary;
            CreatedBy = createToUser;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Salary { get; private set; }
        public DateTime CreatedOn { get; private set; } = DateTime.Now;
        public DateTime? UpdatedOn { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public string? CreatedBy { get; private set; }
        public string? UpdatedBy { get; private set; }
        public string? DeletedBy { get; private set; }
        public bool IsDeleted { get; private set; }

        public bool Update(string name, decimal salary, string userModified)
        {
            if (!userModified.IsNullOrEmpty())
            {
                Name = name;
                Salary = salary;
                UpdatedBy = userModified;
                return true;
            }
            return false;
        }
    }
}
