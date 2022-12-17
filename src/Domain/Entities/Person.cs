namespace Domain
{
    public class Person : Entity<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmployeeId { get; set; }

    }
}
