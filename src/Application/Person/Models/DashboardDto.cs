using Common;
using System.Collections.Generic;

namespace Application
{
    public class DashboardDto : BaseDto
    {
        public IEnumerable<PersonDto> Persons { get; set; }
    }
}
