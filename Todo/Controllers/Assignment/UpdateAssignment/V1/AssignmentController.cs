using V1 = Todo.Controllers.Assignment.UpdateAssignment.V1;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Controllers {
    public partial class AssignmentController {
        [HttpPut("v1/update")]
        public IActionResult UpdateAssignment(V1.Models.UpdateAssignment updateAssignment) {
            var updateAssignmentDto = new V1.Adapters.ToUpdateAssignmentDtoAdapter(updateAssignment);
            assignmentService.Update(updateAssignmentDto);
            return Ok();
        }
    }
}
