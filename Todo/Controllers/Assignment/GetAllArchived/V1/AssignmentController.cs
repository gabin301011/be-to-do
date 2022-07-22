using Microsoft.AspNetCore.Mvc;
using Todo.Controllers.Assignment.GetAllArchived.V1.Converters;
using V1 = Todo.Controllers.Assignment.GetAllArchived.V1;

namespace Todo.Controllers {
    public partial class AssignmentController {
        [HttpGet("v1/archived")]
        public IEnumerable<V1.Models.AssignmentArchived> GetAllArchived () {
            var assignmentDtos = assignmentService.GetAllArchived();
            return assignmentDtos.ToAssignments();
        }
    }
}
