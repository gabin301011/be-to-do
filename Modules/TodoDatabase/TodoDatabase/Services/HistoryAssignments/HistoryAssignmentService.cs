using TodoDatabase.Database.Models;
using TodoDatabase.Repositories.HistoryAssignments;
using TodoDatabase.Services.HistoryAssignments.Converters;

namespace TodoDatabase.Services.HistoryAssignments {
    public class HistoryAssignmentService : IHistoryAssignmentService {
        private readonly IHistoryAssignmentRepo historyAssignmentRepo;

        public HistoryAssignmentService(IHistoryAssignmentRepo historyAssignmentRepo) {
            this.historyAssignmentRepo = historyAssignmentRepo;
        }

        public IEnumerable<Dtos.HistoryAssignmentDto> GetByAssignmentId(int assignmentId) {
            return GetAll().Where(x => x.AssignmentId == assignmentId)
                .ToList()
                .OrderBy(x => x.Date);
        }

        public IEnumerable<Dtos.HistoryAssignmentDto> GetAll() {
            return historyAssignmentRepo.GetAll()
                .ToHistoryAssignmentDtos();
        }

        public Dtos.HistoryAssignmentDto Add(Dtos.IAddHistoryAssignmentDto addHistoryAssignmentDto) {
            var addHistoryAssignment = new HistoryAssignment {
                Action = addHistoryAssignmentDto.Action,
                AssignmentId = addHistoryAssignmentDto.AssignmentId,
                Date = DateTime.Now
            };
            var newHistoryAssignment = historyAssignmentRepo.Add(addHistoryAssignment);
            return newHistoryAssignment.ToHistoryAssignmentDto();
        }
    }
}
