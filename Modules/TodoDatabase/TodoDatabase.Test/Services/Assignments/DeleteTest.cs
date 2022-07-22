using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TodoDatabase.Database;
using TodoDatabase.Database.Models;
using TodoDatabase.Repositories.Assignments;
using TodoDatabase.Services.Assignments;
using Xunit;

namespace TodoDatabase.Test.Services.Assignments {
    public class DeleteTest {
        private const int ASSIGNMENT_ID = 100;
        private const int RETURN_COUNT_ZERO = 0;

        public DbContextOptions<TodoDbContext> InitDb() {
            return new DbContextOptionsBuilder<TodoDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public void When_ElementNotExist_Should_ThrowNotFindElementException() {
            //Init
            TodoDbContext dbContext = new TodoDbContext(InitDb());
            var assignmentRepo = new AssignmentRepo(dbContext);
            var assignmentService = new AssignmentService(assignmentRepo);
            //Assert
            Assert.Throws<Exception>(() => assignmentService.Delete(ASSIGNMENT_ID));
        }

        [Fact]
        public void When_ElementExistInDb_Should_DeleteElementAndReturnZeroElement() {
            //Init
            TodoDbContext dbContext = new TodoDbContext(InitDb());
            InitAssignmentOne(dbContext);
            var assignmentRepo = new AssignmentRepo(dbContext);
            var assignmentService = new AssignmentService(assignmentRepo);
            //Act
            assignmentService.Delete(ASSIGNMENT_ID);
            var assignmentsCount = dbContext.Assignments.Count();
            //Assert
            Assert.Equal(RETURN_COUNT_ZERO, assignmentsCount);
        }

        private void InitAssignmentOne(TodoDbContext dbContext) {
            var oneAssignment = new Assignment {
                Id = 100,
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
