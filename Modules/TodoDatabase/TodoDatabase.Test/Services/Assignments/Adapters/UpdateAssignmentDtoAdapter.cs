using System;
using TodoDatabase.Database.Enums;
using TodoDatabase.Services.Assignments.Dtos;

namespace TodoDatabase.Test.Services.Assignments.Adapters {
    internal class UpdateAssignmentDtoAdapter : IUpdateAssignmentDto {
        private readonly int id;
        private readonly string? name;
        private readonly string? description;
        private readonly bool? isArchived;
        private readonly StatusEnum? status;
        private readonly PriorityEnum? priority;
        private readonly DateTime? completedAt;
        private readonly DateTime? deletedAt;
        public UpdateAssignmentDtoAdapter(
            int id,
            string? name = null,
            string? description = null,
            bool? isArchived = null,
            StatusEnum? status = null,
            PriorityEnum? priority = null,
            DateTime? completedAt = null,
            DateTime? deletedAt = null
        ) {
            this.id = id;
            this.name = name;
            this.description = description;
            this.isArchived = isArchived;
            this.status = status;
            this.priority = priority;
            this.completedAt = completedAt;
            this.deletedAt = deletedAt;
        }
        public int Id => id;
        public string? Name => name;
        public string? Description => description;
        public bool? IsArchived => isArchived;
        StatusEnum? IUpdateAssignmentDto.Status => status;
        PriorityEnum? IUpdateAssignmentDto.Priority => priority;
        DateTime? IUpdateAssignmentDto.CompletedAt => completedAt;
        DateTime? IUpdateAssignmentDto.DateDelete => deletedAt;
    }
}
