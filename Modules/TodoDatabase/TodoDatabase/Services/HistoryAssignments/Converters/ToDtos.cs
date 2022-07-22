using TodoDatabase.Database.Models;

namespace TodoDatabase.Services.HistoryAssignments.Converters {
    internal static class ToDtos {
        public static Dtos.HistoryAssignmentDto ToHistoryAssignmentDto(this HistoryAssignment @this) {
            return new Dtos.HistoryAssignmentDto(
                @this.Id,
                @this.Action,
                @this.Date,
                @this.AssignmentId
                );
        }

        public static IEnumerable<Dtos.HistoryAssignmentDto> ToHistoryAssignmentDtos(this IEnumerable<HistoryAssignment> @this) {
            return @this.ToList().ConvertAll(x => x.ToHistoryAssignmentDto());
        }
    }
}
