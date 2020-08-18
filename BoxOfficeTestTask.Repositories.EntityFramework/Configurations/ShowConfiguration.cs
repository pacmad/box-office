using BoxOfficeTestTask.Models.Shows;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoxOfficeTestTask.Repositories.EntityFramework.Configurations
{
    class ShowConfiguration : IEntityTypeConfiguration<Show>
    {
        public void Configure(EntityTypeBuilder<Show> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
