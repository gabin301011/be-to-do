using System.ComponentModel.DataAnnotations.Schema;

namespace TodoDatabase.Database.Models {
    [Table("history_assignment", Schema = "todo")]
    public class HistoryAssignment {
        [Column("id")]
        public int Id { get; set; }
        [Column("action")]
        public string Action { get; set; } = string.Empty;
        [Column("date", TypeName = "timestamp without time zone")]
        public DateTime Date  { get; set; }
        [Column("assignment_id")]
        public int AssignmentId { get; set; }
        //--------------
        public Assignment? Assignment { get; set; }
    }
}
