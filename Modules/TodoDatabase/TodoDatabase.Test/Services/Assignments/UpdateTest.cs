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
    public class UpdateTest {
        private const int ASSIGNMENT_ID = 20;
        private const string OLD_NAME = "TestName";
        private const string NEW_NAME = "NewName";
        private const string OLD_DESCRIPTION = "TestDescription";
        private const string NEW_DESCRIPTION = "NewDescription";

        public DbContextOptions<TodoDbContext> InitDb() {
            return new DbContextOptionsBuilder<TodoDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public void When_ElementNotExist_Should_ThrowNotFindException() {
            //Init
            TodoDbContext dbContext = new TodoDbContext(InitDb());
            var assignmentRepo = new AssignmentRepo(dbContext);
            var assignmentService = new AssignmentService(assignmentRepo);
            //Act
            var updateAssignmentDtoAdapter = new UpdateAssignmentDtoAdapter(id: ASSIGNMENT_ID, name: NEW_NAME, description: NEW_DESCRIPTION);
            //Assert
            Assert.Throws<Exception>(() => assignmentService.Update(updateAssignmentDtoAdapter));
        }

        [Fact]
        public void When_ElementIsExist_Should_UpdateData() {
            //Init
            TodoDbContext dbContext = new TodoDbContext(InitDb());
            InitAssignmentOne(dbContext);
            var assignmentRepo = new AssignmentRepo(dbContext);
            var assignmentService = new AssignmentService(assignmentRepo);
            //Act
            var updateAssignmentDtoAdapter = new UpdateAssignmentDtoAdapter(id: ASSIGNMENT_ID, name: NEW_NAME, description: NEW_DESCRIPTION);
            assignmentService.Update(updateAssignmentDtoAdapter);
            var getAssignment = dbContext.Assignments
                .Where(x => x.Id == ASSIGNMENT_ID)
                .First();
            //Assert
            Assert.Equal(NEW_NAME, getAssignment.Name);
            Assert.Equal(NEW_DESCRIPTION, getAssignment.Description);
            Assert.NotEqual(OLD_NAME, getAssignment.Name);
            Assert.NotEqual(OLD_DESCRIPTION, getAssignment.Description);
        }

        private void InitAssignmentOne(TodoDbContext dbContext) {
            var oneAssignment = new Assignment {
                Id = ASSIGNMENT_ID,
                Name = OLD_NAME,
                Description = OLD_DESCRIPTION,
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
