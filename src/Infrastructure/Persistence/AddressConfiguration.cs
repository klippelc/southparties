using Common;
using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Infrastructure
{
    public class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            ToTable(nameof(Address));
            MapToStoredProcedures();

            Property(p => p.Address1).IsRequired().HasMaxLength(AppConstants.HasMaxLength48);
            Property(p => p.City).IsRequired().HasMaxLength(AppConstants.HasMaxLength24);
            Property(p => p.State).HasMaxLength(AppConstants.HasMaxLength24);

            //HasMany(p => p.Parts).WithRequired(p => p.BidQuote).HasForeignKey(p => p.BidQuoteId).WillCascadeOnDelete(false);
            //Ignore(p => p.SetStatus);
        }
    }
}