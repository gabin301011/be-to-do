using System.ComponentModel.DataAnnotations.Schema;

namespace TodoDatabase.Database.Models {
    [Table("assignment", Schema = "todo")]
    public class Assignment {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; } = string.Empty;
        [Column("description")]
        public string? Description { get; set; }
        [Column("is_archived")]
        public bool IsArchived { get; set; }
        [Column("status")]
        public Enums.StatusEnum Status { get; set; }
        [Column("priority")]
        public Enums.PriorityEnum Priority { get; set; }
        [Column("created_at", TypeName = "timestamp without time zone")]
        public DateTime CreatedAt { get; set; }
        [Column("completed_at", TypeName = "timestamp without time zone")]
        public DateTime? CompletedAt { get; set; }
        [Column("date_delete", TypeName = "timestamp without time zone")]
        public DateTime? DateDelete { get; set; }
        //---------------
        public IEnumerable<HistoryAssignment>? HistoryAssignments { get; set; }
    }
}
