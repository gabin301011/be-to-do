using TodoDatabase.Database.Enums;

namespace TodoDatabase.Services.Assignments.Dtos {
    public class AssigmentDto {
        public AssigmentDto(
            int id,
            string name,
            string? description,
            bool isArchived,
            StatusEnum status,
            PriorityEnum priority,
            DateTime createdAt,
            DateTime? completedAt,
            DateTime? dateDelete
        ) {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.IsArchived = isArchived;
            this.Status = status;
            this.Priority = priority;
            this.CreatedAt = createdAt;
            this.CompletedAt = completedAt;
            this.DateDelete = dateDelete;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsArchived { get; set; }
        public StatusEnum Status { get; set; }
        public PriorityEnum Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime? DateDelete { get; set; }
    }
}
