using V1 = Todo.Controllers.Assignment.GetAssignmentById.V1;
using Microsoft.AspNetCore.Mvc;
using Todo.Controllers.Assignment.GetAssignmentById.V1.Converters;

namespace Todo.Controllers {
    public partial class AssignmentController {
        [HttpGet("v1/get-by-id/{id}")]
        public V1.Models.AssignmentById GetById(int id) {
            var assignmentDto = assignmentService.GetById(id);
            return assignmentDto.ToAssignment();
        }
    }
}
