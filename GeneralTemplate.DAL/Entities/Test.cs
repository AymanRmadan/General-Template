namespace GeneralTemplate.DAL.Entities
{
    public class Test : Base
    {
        public Test()
        {

        }
        public Test(string name, decimal salary, string createToUser)
        {
            Name = name;
            Salary = salary;
            // CreatedBy = createToUser;
        }

        public string Name { get; private set; }
        public decimal Salary { get; private set; }


        public bool Update(string name, decimal salary, string userModified)
        {
            if (!userModified.IsNullOrEmpty())
            {
                Name = name;
                Salary = salary;
                // UpdatedBy = userModified;
                return true;
            }
            return false;
        }
    }
}
