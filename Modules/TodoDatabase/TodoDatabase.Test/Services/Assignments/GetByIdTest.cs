using Microsoft.EntityFrameworkCore;
using System;
using TodoDatabase.Database;
using TodoDatabase.Database.Models;
using TodoDatabase.Repositories.Assignments;
using TodoDatabase.Services.Assignments;
using Xunit;

namespace TodoDatabase.Test.Services.Assignments {
    public class GetByIdTest {
        private const int ASSIGNMENT_ID = 30;

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
            //Assert
            Assert.Throws<Exception>(() => assignmentService.GetById(ASSIGNMENT_ID));
        }

        [Fact]
        public void When_ElementExistInDb_Should_ReturnElement() {
            //Init
            TodoDbContext dbContext = new TodoDbContext(InitDb());
            InitAssignments(dbContext);
            var assignmentRepo = new AssignmentRepo(dbContext);
            var assignmentService = new AssignmentService(assignmentRepo);
            //Act
            var result = assignmentService.GetById(ASSIGNMENT_ID);
            //Assert
            Assert.Equal(ASSIGNMENT_ID, result.Id);
        }

        private void InitAssignments(TodoDbContext dbContext) {
            var assignmentOne = new Assignment
            {
                Id = 20,
                Name = "TestName1",
                Description = "TestDescription1",
                IsArchived = false,
                Status = Database.Enums.StatusEnum.InProgres,
                Priority = Database.Enums.PriorityEnum.Higest,
                CreatedAt = DateTime.Now
            };
            var assignmentTwo = new Assignment {
                Id = 30,
                Name = "TestName2",
                Description = "TestDescription2",
                IsArchived = false,
                Status = Database.Enums.StatusEnum.Complete,
                Priority = Database.Enums.PriorityEnum.Higest,
                CreatedAt = DateTime.Now
            };
            dbContext.Assignments.Add(assignmentOne);
            dbContext.Assignments.Add(assignmentTwo);
            dbContext.SaveChanges();
        }
    }
}
