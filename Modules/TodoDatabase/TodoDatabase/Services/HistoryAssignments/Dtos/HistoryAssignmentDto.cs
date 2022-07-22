namespace TodoDatabase.Services.HistoryAssignments.Dtos {
    public class HistoryAssignmentDto {
        public HistoryAssignmentDto(
            int id,
            string action,
            DateTime date,
            int assignmentId
        ) {
            this.Id = id;
            this.Action = action;
            this.Date = date;
            this.AssignmentId = assignmentId;
        }
        public int Id { get; set; }
        public string Action { get; set; }
        public DateTime Date { get; set; }
        public int AssignmentId { get; set; }
    }
}
