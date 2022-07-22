using Microsoft.AspNetCore.Mvc;
using Todo.Controllers.HistoryAssignment.GetHistoryAssignmentByAssignmentId.V1.Converters;
using V1 = Todo.Controllers.HistoryAssignment.GetHistoryAssignmentByAssignmentId.V1;

namespace Todo.Controllers {
    public partial class HistoryAssignmentController {
        [HttpGet("v1/get-by-assignment-id/{assignmentId}")]
        public IEnumerable<V1.Models.HistoryAssignment> GetByAssignmentId(int assignmentId) {
            var historyAssignmentDtos = historyAssignmentService.GetByAssignmentId(assignmentId);
            return historyAssignmentDtos.ToHistoryAssignments();
        }
    }
}
