using TodoDatabase.Database.Enums;

namespace Todo.Controllers.Assignment.GetByStatus.V1.Models {
    public class Assignment {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsArchived { get; set; }
        public StatusEnum Status { get; set; }
        public PriorityEnum Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime? DateDelete { get; set; }
    }
}
