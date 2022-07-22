using V1 = Todo.Controllers.Assignment.AddAssignment.V1;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Controllers {
    public partial class AssignmentController {
        [HttpPost("v1/add")]
        public IActionResult AddAssignment(V1.Models.AddAssignment addAssignment) {
            var addAssignmentDto = new V1.Adapters.ToAddAssignmentDtoAdapter(addAssignment);
            assignmentService.Add(addAssignmentDto);
            return Ok();
        }
    }
}
