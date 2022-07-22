using TodoDatabase.Database.Enums;

namespace TodoDatabase.Services.Assignments.Dtos {
    public interface IAddAssignmentDto {
        public string Name { get; }
        public string? Description { get; }
        public PriorityEnum Priority { get; }
    }
}
