using System;
using System.Collections.Generic;
using System.Linq;
using TodoDatabase.Database.Enums;
using TodoDatabase.Services.Assignments.Dtos;

namespace TodoDatabase.Test.Services.Assignments.Adapters {
    internal class AddAssignmentDtoAdapter : IAddAssignmentDto {
        private readonly string name;
        private readonly string? description;
        private readonly PriorityEnum priority;

        public AddAssignmentDtoAdapter(
            string name,
            string? description,
            PriorityEnum priority
        ) {
            this.name = name;
            this.description = description;
            this.priority = priority;
        }
        public string Name => name;
        public string? Description => description;
        public PriorityEnum Priority => priority;
    }
}
