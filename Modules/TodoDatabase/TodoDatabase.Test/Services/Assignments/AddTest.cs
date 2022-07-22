using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TodoDatabase.Database;
using TodoDatabase.Database.Models;
using TodoDatabase.Repositories.Assignments;
using TodoDatabase.Services.Assignments;
using TodoDatabase.Test.Services.Assignments.Adapters;
using Xunit;

namespace TodoDatabase.Test.Services.Assignments {
    public class AddTest {
        private const int RETRN_COUNT_ONE = 1;
        private const int RETRN_COUNT_TWO = 2;

        public DbContextOptions<TodoDbContext> InitDb() {
            return new DbContextOptionsBuilder<TodoDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public void When_DbIsEmpty_Should_AddElementAndReturnOneElement() {
            //Init
            TodoDbContext dbContext = new TodoDbContext(InitDb());
            var assignmentRepo = new AssignmentRepo(dbContext);
            var assignmentService = new AssignmentService(assignmentRepo);
            //Act
            var addAssignmentDtoAdapter = new AddAssignmentDtoAdapter("TestName", "TestDescription", Database.Enums.PriorityEnum.Higest);
            assignmentService.Add(addAssignmentDtoAdapter);
            var assignmentsCount = dbContext.Assignments.Count();
            //Assert
            Assert.Equal(RETRN_COUNT_ONE, assignmentsCount);
        }

        [Fact]
        public void When_InDbExistOneElement_Should_AddElementAndReturnTwoElement() {
            //Init
            TodoDbContext dbContext = new TodoDbContext(InitDb());
            InitAssignmentOne(dbContext);
            var assignmentRepo = new AssignmentRepo(dbContext);
            var assignmentService = new AssignmentService(assignmentRepo);
            //Act
            var addAssignmentDtoAdapter = new AddAssignmentDtoAdapter("TestName", "TestDescription", Database.Enums.PriorityEnum.Higest);
            assignmentService.Add(addAssignmentDtoAdapter);
            var assignmentsCount = dbContext.Assignments.Count();
            //Assert
            Assert.Equal(RETRN_COUNT_TWO, assignmentsCount);
        }

        private void InitAssignmentOne(TodoDbContext dbContext) {
            var oneAssignment = new Assignment {
                Id = 1,
                Name = "TestName",
                Description = "TestDescription",
                IsArchived = false,
                Status = Database.Enums.StatusEnum.Todo,
                Priority = Database.Enums.PriorityEnum.Higest,
                CreatedAt = DateTime.Now
            };
            dbContext.Assignments.Add(oneAssignment);
            dbContext.SaveChanges();
        }
    }
}
