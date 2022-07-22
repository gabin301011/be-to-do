using TodoDatabase.Database.Models;

namespace TodoDatabase.Repositories.HistoryAssignments {
    public interface IHistoryAssignmentRepo {
        HistoryAssignment Add(HistoryAssignment historyAssignment);
        IEnumerable<HistoryAssignment> GetAll();
    }
}
