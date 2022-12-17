using Domain;
using Infrastructure;
using MediatR;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application
{
    public class PersonsQuery : IRequest<DashboardDto>
    {
        public class Handler : IRequestHandler<PersonsQuery, DashboardDto>
        {
            private readonly IDbService _dbService;

            public Handler(IDbService dbService)
            {
                _dbService = dbService;
            }

            public async Task<DashboardDto> Handle(PersonsQuery request, CancellationToken cancellationToken)
            {
                var persons = await _dbService.Set<Person>().AsNoTracking()
                    .Select(p => new PersonDto
                    {
                        DomainKey = p.DomainKey,
                        FirstName = p.FirstName,
                        LastName = p.LastName
                    })
                    .ToListAsync();

                return new DashboardDto { Persons = persons };
            }
        }
    }
}
