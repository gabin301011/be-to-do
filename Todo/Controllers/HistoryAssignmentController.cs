using Microsoft.AspNetCore.Mvc;
using TodoDatabase.Services.HistoryAssignments;

namespace Todo.Controllers
{
    [Route("api/history-assignment")]
    [ApiController]
    public partial class HistoryAssignmentController : ControllerBase {
        private readonly IHistoryAssignmentService historyAssignmentService;

        public HistoryAssignmentController(IHistoryAssignmentService historyAssignmentService) {
            this.historyAssignmentService = historyAssignmentService;
        }
    }
}
