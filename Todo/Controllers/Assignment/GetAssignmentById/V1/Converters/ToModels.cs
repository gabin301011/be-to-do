using TodoDatabase.Services.Assignments.Dtos;

namespace Todo.Controllers.Assignment.GetAssignmentById.V1.Converters {
    public static class ToModels {
        public static Models.AssignmentById ToAssignment(this AssigmentDto @this) {
            return new Models.AssignmentById {
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
