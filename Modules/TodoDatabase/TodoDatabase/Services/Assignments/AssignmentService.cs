using TodoDatabase.Database.Enums;
using TodoDatabase.Database.Models;
using TodoDatabase.Repositories.Assignments;
using TodoDatabase.Services.Assignments.Converters;

namespace TodoDatabase.Services.Assignments {
    public class AssignmentService : IAssignmentService, IAssignmentCon {
        private readonly IAssignmentRepo assignmentRepo;

        public AssignmentService(IAssignmentRepo assignmentRepo)  {
            this.assignmentRepo = assignmentRepo;
        }

        public Dtos.AssigmentDto GetById(int id) {
            var getAssignment = assignmentRepo.GetById(id);
            if (getAssignment == null) {
                throw new Exception("Assignment not find");
            }
            return getAssignment
                .ToAssignmentDto();
        }

        public IEnumerable<Dtos.AssigmentDto> GetAllArchived() {
            return assignmentRepo.GetAll()
                .Where(x => x.IsArchived == true)
                .ToAssignmentDtos()
                .ToList()
                .OrderByDescending(x => x.CompletedAt);
        }

        public IEnumerable<Dtos.AssigmentDto> GetByStatus(StatusEnum status) {
            return assignmentRepo.GetAll()
                .Where(x => x.Status == status)
                .ToAssignmentDtos()
                .ToList()
                .OrderByDescending(x => x.Priority);
        }

        public IEnumerable<Dtos.AssigmentDto> GetAll() {
            return assignmentRepo.GetAll()
                .ToAssignmentDtos()
                .ToList();
        }

        public void Update(Dtos.IUpdateAssignmentDto updateAssignmentDto) {
            var getAssignment = assignmentRepo.GetById(updateAssignmentDto.Id);
            if (getAssignment == null) {
                throw new Exception("Assignment not find");
            }
            if (updateAssignmentDto.Name != null) {
                getAssignment.Name = updateAssignmentDto.Name;
            }
            if (updateAssignmentDto.Description != null) {
                getAssignment.Description = updateAssignmentDto.Description;
            }
            if (updateAssignmentDto.IsArchived != null) {
                getAssignment.IsArchived = (bool)updateAssignmentDto.IsArchived;
            }
            if (updateAssignmentDto.Status != null) {
                getAssignment.Status = (Database.Enums.StatusEnum)updateAssignmentDto.Status;
            }
            if (updateAssignmentDto.Priority != null) {
                getAssignment.Priority = (Database.Enums.PriorityEnum)updateAssignmentDto.Priority;
            }
            if (updateAssignmentDto.CompletedAt != null) {
                getAssignment.CompletedAt = updateAssignmentDto.CompletedAt;
            }
            if (updateAssignmentDto.DateDelete != null) {
                getAssignment.DateDelete = updateAssignmentDto.DateDelete;
            }
            assignmentRepo.Update(getAssignment);
        }

        public void Delete(int assignmentId) {
            var getAssignment = assignmentRepo.GetById(assignmentId);
            if (getAssignment == null) {
                throw new Exception("Assignment not find");
            }
            assignmentRepo.Delete(getAssignment);
        }

        public Dtos.AssigmentDto Add(Dtos.IAddAssignmentDto addAssignmentDto) {
            var addAssignment = new Assignment {
                Name = addAssignmentDto.Name,
                Description = addAssignmentDto.Description,
                IsArchived = false,
                Status = Database.Enums.StatusEnum.Todo,
                Priority = addAssignmentDto.Priority,
                CreatedAt = DateTime.Now,
                CompletedAt = null,
                DateDelete = null
            };
            var newAssignment = assignmentRepo.Add(addAssignment);
            return newAssignment.ToAssignmentDto();
        }

        public void MoveToArchived()
        {
            throw new NotImplementedException();
        }
    }
}
