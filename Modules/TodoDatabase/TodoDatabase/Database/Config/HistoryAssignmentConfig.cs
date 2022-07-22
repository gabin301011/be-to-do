using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TodoDatabase.Database.Config {
    internal class HistoryAssignmentConfig : IEntityTypeConfiguration<Models.HistoryAssignment> {
        public void Configure(EntityTypeBuilder<Models.HistoryAssignment> builder) {
            builder.HasKey(x => x.Id);
        }
    }
}
