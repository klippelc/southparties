using Common;
using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Infrastructure
{
    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            ToTable(nameof(Person));
            MapToStoredProcedures();

            Property(p => p.FirstName).IsRequired().HasMaxLength(AppConstants.HasMaxLength48);
            Property(p => p.LastName).IsRequired().HasMaxLength(AppConstants.HasMaxLength24);
            Property(p => p.EmployeeId).HasMaxLength(AppConstants.HasMaxLength24);

            //HasMany(p => p.Parts).WithRequired(p => p.BidQuote).HasForeignKey(p => p.BidQuoteId).WillCascadeOnDelete(false);
            //Ignore(p => p.SetStatus);
        }
    }
}