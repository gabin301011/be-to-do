using TodoDatabase.Database.Enums;

namespace TodoDatabase.Services.Assignments {
    public interface IAssignmentService {
        Dtos.AssigmentDto Add(Dtos.IAddAssignmentDto addAssignmentDto);
        void Delete(int assignmentId);
        void Update(Dtos.IUpdateAssignmentDto updateAssignmentDto);
        IEnumerable<Dtos.AssigmentDto> GetAll();
        IEnumerable<Dtos.AssigmentDto> GetByStatus(StatusEnum status);
        Dtos.AssigmentDto GetById(int id);
        IEnumerable<Dtos.AssigmentDto> GetAllArchived();
    }
}
