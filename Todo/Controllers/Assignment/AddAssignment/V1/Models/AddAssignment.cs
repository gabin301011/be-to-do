using TodoDatabase.Database.Enums;

namespace Todo.Controllers.Assignment.AddAssignment.V1.Models {
    public class AddAssignment {
        public string Name { get; set; }
        public string? Description { get; set; }
        public PriorityEnum Priority { get; set; }
    }
}
