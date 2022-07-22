using TodoDatabase.Database;
using TodoDatabase.Database.Models;

namespace TodoDatabase.Repositories.HistoryAssignments {
    public class HistoryAssignmentRepo : IHistoryAssignmentRepo {
        private readonly TodoDbContext dbContext;

        public HistoryAssignmentRepo(TodoDbContext dbContext) {
            this.dbContext = dbContext;
        }

        public HistoryAssignment Add(HistoryAssignment historyAssignment) {
            var addHistoryAssignment = dbContext.HistoryAssignments.Add(historyAssignment);
            dbContext.SaveChanges();
            return addHistoryAssignment.Entity;
        }

        public IEnumerable<HistoryAssignment> GetAll() {
            return dbContext.HistoryAssignments
                .ToList();
        }
    }
}
