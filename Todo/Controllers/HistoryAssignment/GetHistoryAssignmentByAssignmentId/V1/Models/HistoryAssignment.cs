namespace Todo.Controllers.HistoryAssignment.GetHistoryAssignmentByAssignmentId.V1.Models {
    public class HistoryAssignment {
        public int Id { get; set; }
        public string Action { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int AssignmentId { get; set; }
    }
}
