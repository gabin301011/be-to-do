using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TodoDatabase.Database.Config {
    internal class AssignmentConfig : IEntityTypeConfiguration<Models.Assignment> {
        public void Configure(EntityTypeBuilder<Models.Assignment> builder) {
            builder.HasKey(x => x.Id);
            builder.HasQueryFilter(x => x.DateDelete == null);
            builder.HasMany(x => x.HistoryAssignments)
                .WithOne(x => x.Assignment)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.AssignmentId);
        }
    }
}
