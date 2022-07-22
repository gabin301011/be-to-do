namespace TodoDatabase.Services.HistoryAssignments.Dtos {
    public interface IAddHistoryAssignmentDto {
        public string Action { get; }
        public int AssignmentId { get; }
    }
}
