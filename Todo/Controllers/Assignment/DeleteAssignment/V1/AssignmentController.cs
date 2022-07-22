using Microsoft.AspNetCore.Mvc;

namespace Todo.Controllers {
    public partial class AssignmentController {
        [HttpDelete("v1/delete/{id}")]
        public IActionResult Delete(int id) {
            assignmentService.Delete(id);
            return Ok();
        }
    }
}
