using Microsoft.AspNetCore.Mvc;
using V1 = Todo.Controllers.HistoryAssignment.AddHistoryAssignment.V1;

namespace Todo.Controllers {
    public partial class HistoryAssignmentController {
        [HttpPost("v1/add")]
        public IActionResult Add(V1.Models.AddHistoryAssignment addHistoryAssignment) {
            var addHistoryAssignmentDto = new V1.Adapters.ToAddHistoryAssignmentDtoAdapter(addHistoryAssignment);
            historyAssignmentService.Add(addHistoryAssignmentDto);
            return Ok();
        }
    }
}
