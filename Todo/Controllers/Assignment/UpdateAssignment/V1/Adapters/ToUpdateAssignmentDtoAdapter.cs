using TodoDatabase.Database.Enums;
using TodoDatabase.Services.Assignments.Dtos;

namespace Todo.Controllers.Assignment.UpdateAssignment.V1.Adapters {
    public class ToUpdateAssignmentDtoAdapter : IUpdateAssignmentDto {
        private readonly Models.UpdateAssignment updateAssignment;

        public ToUpdateAssignmentDtoAdapter(Models.UpdateAssignment updateAssignment) {
            this.updateAssignment = updateAssignment;
        }

        public int Id => updateAssignment.Id;
        public string? Name => updateAssignment.Name;
        public string? Description => updateAssignment.Description;
        public bool? IsArchived => updateAssignment.IsArchived;
        public StatusEnum? Status => updateAssignment.Status;
        public PriorityEnum? Priority => updateAssignment.Priority;
        public DateTime? CompletedAt => updateAssignment.CompletedAt;
        public DateTime? DateDelete => updateAssignment.DateDelete;
    }
}
