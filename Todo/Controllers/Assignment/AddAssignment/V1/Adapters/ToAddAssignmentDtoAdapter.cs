using TodoDatabase.Database.Enums;
using TodoDatabase.Services.Assignments.Dtos;

namespace Todo.Controllers.Assignment.AddAssignment.V1.Adapters {
    public class ToAddAssignmentDtoAdapter : IAddAssignmentDto {
        private readonly Models.AddAssignment addAssignment;

        public ToAddAssignmentDtoAdapter(Models.AddAssignment addAssignment) {
            this.addAssignment = addAssignment;
        }

        public string Name => addAssignment.Name;
        public string? Description => addAssignment.Description;
        public PriorityEnum Priority => addAssignment.Priority;
    }
}
