using TodoDatabase.Database;
using TodoDatabase.Database.Models;

namespace TodoDatabase.Repositories.Assignments {
    public class AssignmentRepo : IAssignmentRepo {
        private readonly TodoDbContext dbContext;
        public AssignmentRepo(TodoDbContext dbContext) {
            this.dbContext = dbContext;
        }

        public Assignment Add(Assignment assignment) {
            var addAssignment = dbContext.Assignments.Add(assignment);
            dbContext.SaveChanges();
            return addAssignment.Entity;
        }

        public void Update(Assignment assignment) {
            dbContext.Assignments.Update(assignment);
            dbContext.SaveChanges();
        }

        public void Delete(Assignment assignment) {
            dbContext.Assignments.Remove(assignment);
            dbContext.SaveChanges();
        }

        public IEnumerable<Assignment> GetAll() {
            var adf = dbContext.Assignments;
            return dbContext.Assignments
                .ToList();
        }

        public Assignment? GetById(int id) {
            return dbContext.Assignments
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }
    }
}
