using TodoDatabase.Services.Assignments.Dtos;

namespace Todo.Controllers.Assignment.GetByStatus.V1.Converters {
    public static class ToModels {
        public static IEnumerable<Models.Assignment> ToAssignments(this IEnumerable<AssigmentDto> @this) {
            return @this.ToList().ConvertAll(x => x.ToAssignment());
        }

        public static Models.Assignment ToAssignment(this AssigmentDto @this) {
            return new Models.Assignment {
                Id = @this.Id,
                Name = @this.Name,
                Description = @this.Description,
                IsArchived = @this.IsArchived,
                Status = @this.Status,
                Priority = @this.Priority,
                CreatedAt = @this.CreatedAt,
                CompletedAt = @this.CompletedAt,
                DateDelete = @this.DateDelete
            };
        }
    }
}
