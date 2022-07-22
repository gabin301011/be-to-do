using TodoDatabase.Database.Enums;

namespace Todo.Controllers.Assignment.UpdateAssignment.V1.Models {
    public class UpdateAssignment {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? IsArchived { get; set; }
        public StatusEnum? Status { get; set; }
        public PriorityEnum? Priority { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime? DateDelete { get; set; }
    }
}
