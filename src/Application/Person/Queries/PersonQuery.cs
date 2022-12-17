using Domain;
using FluentValidation;
using Infrastructure;
using MediatR;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application
{
    public class PersonQueryValidator : AbstractValidator<PersonQuery>
    {
        public PersonQueryValidator()
        {
            RuleFor(p => p.DomainKey).NotEmpty().NotNull();
        }
    }

    public class PersonQuery : IRequest<PersonDto>
    {
        public PersonQuery(string domainKey)
        {
            DomainKey = domainKey;
        }

        public string DomainKey { get; }

        public class Handler : IRequestHandler<PersonQuery, PersonDto>
        {
            private readonly IDbService _dbService;

            public Handler(IDbService dbService)
            {
                _dbService = dbService;
            }

            public async Task<PersonDto> Handle(PersonQuery request, CancellationToken cancellationToken)
            {
                var person = await _dbService.Set<Person>()
                        .Where(p => p.DomainKey.Equals(request.DomainKey))
                        .Select(p => new PersonDto
                        {
                            DomainKey = p.DomainKey,
                            EmployeeId = p.EmployeeId,
                            FirstName = p.FirstName,
                            LastName = p.LastName
                        })
                        .FirstOrDefaultAsync();

                return person;
            }
        }
    }
}
