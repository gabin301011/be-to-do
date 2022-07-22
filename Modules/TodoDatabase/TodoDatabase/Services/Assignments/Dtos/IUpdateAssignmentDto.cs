using TodoDatabase.Database.Enums;

namespace TodoDatabase.Services.Assignments.Dtos {
    public interface IUpdateAssignmentDto {
        public int Id { get; }
        public string? Name { get; }
        public string? Description { get; }
        public bool? IsArchived { get; }
        public StatusEnum? Status { get; }
        public PriorityEnum? Priority { get; }
        public DateTime? CompletedAt { get; }
        public DateTime? DateDelete { get; }
    }
}
