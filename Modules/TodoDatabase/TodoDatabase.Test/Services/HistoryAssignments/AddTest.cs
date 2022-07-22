using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TodoDatabase.Database;
using TodoDatabase.Database.Models;
using TodoDatabase.Repositories.HistoryAssignments;
using TodoDatabase.Services.HistoryAssignments;
using TodoDatabase.Test.Services.HistoryAssignments.Adapters;
using Xunit;

namespace TodoDatabase.Test.Services.HistoryAssignments {
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
            var hisotryAssignmentRepo = new HistoryAssignmentRepo(dbContext);
            var historyAssignmentService = new HistoryAssignmentService(hisotryAssignmentRepo);
            //Act
            var addHistoryAssignmentDtoAdapter = new AddHistoryAssignmentDtoAdapter("TestAcrion", 200);
            historyAssignmentService.Add(addHistoryAssignmentDtoAdapter);
            var historyAssignmentsCount = dbContext.HistoryAssignments.Count();
            //Assert
            Assert.Equal(RETRN_COUNT_ONE, historyAssignmentsCount);
        }

        [Fact]
        public void When_InDbExistOneElement_Should_AddElementAndReturnTwoElement()
        {
            //Init
            TodoDbContext dbContext = new TodoDbContext(InitDb());
            InitHistoryAssignmentOne(dbContext);
            var hisotryAssignmentRepo = new HistoryAssignmentRepo(dbContext);
            var historyAssignmentService = new HistoryAssignmentService(hisotryAssignmentRepo);
            //Act
            var addHistoryAssignmentDtoAdapter = new AddHistoryAssignmentDtoAdapter("TestAcrion", 200);
            historyAssignmentService.Add(addHistoryAssignmentDtoAdapter);
            var historyAssignmentsCount = dbContext.HistoryAssignments.Count();
            //Assert
            Assert.Equal(RETRN_COUNT_TWO, historyAssignmentsCount);
        }

        private void InitHistoryAssignmentOne(TodoDbContext dbContext) {
            var oneHistoryAssignment = new HistoryAssignment {
                Id = 1,
                Action = "TestAction",
                AssignmentId = 121,
                Date = DateTime.Now
            };
            dbContext.HistoryAssignments.Add(oneHistoryAssignment);
            dbContext.SaveChanges();
        }
    }
}
