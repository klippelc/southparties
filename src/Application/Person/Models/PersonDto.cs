using Common;

namespace Application
{
    public class PersonDto : BaseDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string EmployeeId { get; set; }
    }
}
