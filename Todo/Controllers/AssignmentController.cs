using Microsoft.AspNetCore.Mvc;
using TodoDatabase.Services.Assignments;

namespace Todo.Controllers {
    [Route("api/assignment")]
    [ApiController]
    public partial class AssignmentController : ControllerBase {
        private readonly IAssignmentService assignmentService;

        public AssignmentController(IAssignmentService assignmentService) {
            this.assignmentService = assignmentService;
        }
    }
}
