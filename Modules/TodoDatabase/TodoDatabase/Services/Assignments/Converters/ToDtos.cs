using TodoDatabase.Database.Models;

namespace TodoDatabase.Services.Assignments.Converters {
    internal static class ToDtos {
        public static Dtos.AssigmentDto ToAssignmentDto(this Assignment @this) {
            return new Dtos.AssigmentDto(
                @this.Id,
                @this.Name,
                @this.Description,
                @this.IsArchived,
                @this.Status,
                @this.Priority,
                @this.CreatedAt,
                @this.CompletedAt,
                @this.DateDelete
                );
        }

        public static IEnumerable<Dtos.AssigmentDto> ToAssignmentDtos(this IEnumerable<Assignment> @this) {
            return @this.ToList().ConvertAll(x => x.ToAssignmentDto());
        }
    }
}
