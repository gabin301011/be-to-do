using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TodoDatabase.Database;
using TodoDatabase.Database.Models;
using TodoDatabase.Repositories.Assignments;
using TodoDatabase.Services.Assignments;
using Xunit;

namespace TodoDatabase.Test.Services.Assignments {
    public class GetAllTest {
        private const int RETURN_COUNT_TWO = 2;

        public DbContextOptions<TodoDbContext> InitDb() {
            return new DbContextOptionsBuilder<TodoDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public void When_DbIsEmpty_Should_ReturnZeroElement() {
            //Init
            TodoDbContext dbContext = new TodoDbContext(InitDb());
            var assignmentRepo = new AssignmentRepo(dbContext);
            var assignmentService = new AssignmentService(assignmentRepo);
            //Act
            var result = assignmentService.GetAll();
            //Assert
            Assert.Empty(result);
        }

        [Fact]
        public void When_InDbExistTwoElements_Should_ReturnTwoElement() {
            //Init
            TodoDbContext dbContext = new TodoDbContext(InitDb());
            InitAssignments(dbContext);
            var assignmentRepo = new AssignmentRepo(dbContext);
            var assignmentService = new AssignmentService(assignmentRepo);
            //Act
            var result = assignmentService.GetAll();
            //Assert
            Assert.Equal(RETURN_COUNT_TWO, result.Count());
        }

        private void InitAssignments(TodoDbContext dbContext) {
            var assignmentOne = new Assignment {
                Id = 11,
                Name = "TestName1",
                Description = "TestDescription1",
                IsArchived = false,
                Status = Database.Enums.StatusEnum.InProgres,
                Priority = Database.Enums.PriorityEnum.Higest,
                CreatedAt = DateTime.Now
            };
            var assignmentTwo = new Assignment {
                Id = 12,
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
