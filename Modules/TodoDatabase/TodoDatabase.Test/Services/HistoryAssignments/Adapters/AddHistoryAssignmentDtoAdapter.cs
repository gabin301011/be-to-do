using TodoDatabase.Services.HistoryAssignments.Dtos;

namespace TodoDatabase.Test.Services.HistoryAssignments.Adapters {
    internal class AddHistoryAssignmentDtoAdapter : IAddHistoryAssignmentDto {
        private readonly string action;
        private readonly int assignmentId;
        public AddHistoryAssignmentDtoAdapter(string action, int assignmentId) {
            this.action = action;
            this.assignmentId = assignmentId;
        }
        public string Action => action;
        public int AssignmentId => assignmentId;
    }
}
