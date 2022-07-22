using TodoDatabase.Services.HistoryAssignments.Dtos;

namespace Todo.Controllers.HistoryAssignment.AddHistoryAssignment.V1.Adapters {
    public class ToAddHistoryAssignmentDtoAdapter : IAddHistoryAssignmentDto {
        private readonly Models.AddHistoryAssignment addHistoryAssignment;
        public ToAddHistoryAssignmentDtoAdapter(Models.AddHistoryAssignment addHistoryAssignment) {
            this.addHistoryAssignment = addHistoryAssignment;
        }
        public string Action => addHistoryAssignment.Action;
        public int AssignmentId => addHistoryAssignment.AssignmentId;
    }
}
