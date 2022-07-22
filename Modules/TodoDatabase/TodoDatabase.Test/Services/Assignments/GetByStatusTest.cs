using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TodoDatabase.Database;
using TodoDatabase.Database.Models;
using TodoDatabase.Repositories.Assignments;
using TodoDatabase.Services.Assignments;
using Xunit;

namespace TodoDatabase.Test.Services.Assignments {
    public class GetByStatusTest {
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
            var result = assignmentService.GetByStatus(Database.Enums.StatusEnum.Todo);
            //Assert
            Assert.Empty(result);
        }

        [Fact]
        public void When_InDbExistOneElementWithStatusToDo_Should_ReturOneElement() {
            //Init
            TodoDbContext dbContext = new TodoDbContext(InitDb());
            InitAssignmentOne(dbContext);
            var assignmentRepo = new AssignmentRepo(dbContext);
            var assignmentService = new AssignmentService(assignmentRepo);
            //Act
            var result = assignmentService.GetByStatus(Database.Enums.StatusEnum.Todo);
            //Assert
            Assert.Single(result);
        }

        [Fact]
        public void When_InDbExistElementsWithAnotherStatus_Should_ReturnZeroElement() {
            //Init
            TodoDbContext dbContext = new TodoDbContext(InitDb());
            InitAssignmentsWithAnotherStatus(dbContext);
            var assignmentRepo = new AssignmentRepo(dbContext);
            var assignmentService = new AssignmentService(assignmentRepo);
            //Act
            var result = assignmentService.GetByStatus(Database.Enums.StatusEnum.Todo);
            //Assert
            Assert.Empty(result);
        }

        [Fact]
        public void When_InDbExistTwoElementsWithThisStatus_Should_ReturnTwoElements() {
            //Init
            TodoDbContext dbContext = new TodoDbContext(InitDb());
            InitAssignmentWithOneStatus(dbContext);
            var assignmentRepo = new AssignmentRepo(dbContext);
            var assignmentService = new AssignmentService(assignmentRepo);
            //Act
            var result = assignmentService.GetByStatus(Database.Enums.StatusEnum.Todo);
            //Assert
            Assert.Equal(RETURN_COUNT_TWO, result.Count());
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

        private void InitAssignmentsWithAnotherStatus(TodoDbContext dbContext) {
            var assignmentOne = new Assignment{
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

        private void InitAssignmentWithOneStatus(TodoDbContext dbContext) {
            var assignmentOne = new Assignment {
                Id = 111,
                Name = "TestName1",
                Description = "TestDescription1",
                IsArchived = false,
                Status = Database.Enums.StatusEnum.Todo,
                Priority = Database.Enums.PriorityEnum.Higest,
                CreatedAt = DateTime.Now
            };
            var assignmentTwo = new Assignment {
                Id = 112,
                Name = "TestName2",
                Description = "TestDescription2",
                IsArchived = false,
                Status = Database.Enums.StatusEnum.Todo,
                Priority = Database.Enums.PriorityEnum.Higest,
                CreatedAt = DateTime.Now
            };
            dbContext.Assignments.Add(assignmentOne);
            dbContext.Assignments.Add(assignmentTwo);
            dbContext.SaveChanges();
        }
    }
}
