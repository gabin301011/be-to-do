namespace TodoDatabase.Services.HistoryAssignments {
    public interface IHistoryAssignmentService {
        Dtos.HistoryAssignmentDto Add(Dtos.IAddHistoryAssignmentDto addHistoryAssignmentDto);
        IEnumerable<Dtos.HistoryAssignmentDto> GetByAssignmentId(int assignmentId);
    }
}
