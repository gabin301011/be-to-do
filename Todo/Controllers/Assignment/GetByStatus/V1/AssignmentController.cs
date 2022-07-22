using V1 = Todo.Controllers.Assignment.GetByStatus.V1;
using Microsoft.AspNetCore.Mvc;
using TodoDatabase.Database.Enums;
using Todo.Controllers.Assignment.GetByStatus.V1.Converters;

namespace Todo.Controllers {
    public partial class AssignmentController {
        [HttpGet("v1/get/{status}")]
        public IEnumerable<V1.Models.Assignment> GetByStatus(StatusEnum status) {
            var assignmentDtos = assignmentService.GetByStatus(status);
            return assignmentDtos.ToAssignments();
        }
    }
}
