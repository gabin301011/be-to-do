using TodoDatabase.Database.Models;

namespace TodoDatabase.Repositories.Assignments {
    public interface IAssignmentRepo {
        Assignment Add(Assignment assignment);
        void Update(Assignment assignment);
        void Delete(Assignment assignment);
        IEnumerable<Assignment> GetAll();
        Assignment? GetById(int id);
    }
}
