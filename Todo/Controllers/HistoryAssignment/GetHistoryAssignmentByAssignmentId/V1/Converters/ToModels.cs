using TodoDatabase.Services.HistoryAssignments.Dtos;

namespace Todo.Controllers.HistoryAssignment.GetHistoryAssignmentByAssignmentId.V1.Converters {
    public static class ToModels {

        public static IEnumerable<Models.HistoryAssignment> ToHistoryAssignments(this IEnumerable<HistoryAssignmentDto> @this) {
            return @this.ToList().ConvertAll(x => x.ToHistoryAssignment());
        }

        public static Models.HistoryAssignment ToHistoryAssignment(this HistoryAssignmentDto @this) {
            return new Models.HistoryAssignment {
                Id = @this.Id,
                Action = @this.Action,
                Date = @this.Date,
                AssignmentId = @this.AssignmentId
            };
        }
    }
}
