using Backend.Data;
using Backend.Logics;
using Backend.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class FunctionTests
    {
        [Test]
        public async Task GetAuthorizedTaskLists()
        {
            // Arrange
            string user1Id = "1", user2Id = "2";
            var tlMockRepository = new Mock<ITaskListRepository>();
            tlMockRepository.Setup(repo => repo.ReadAsync())
                .ReturnsAsync(new List<TaskList>
                {
                    new TaskList() { Id = "1", Name = "List 1", Description = "Description 1", CreatorId = user1Id },
                    new TaskList() { Id = "2", Name = "List 2", Description = "Description 2", CreatorId = user2Id },
                    new TaskList() { Id = "3", Name = "List 3", Description = "Description 3", CreatorId = user2Id },
                });

            var utlMockRepository = new Mock<IUserTaskListRepository>();
            utlMockRepository.Setup(repo => repo.ReadAsync())
                .ReturnsAsync(new List<UserTaskList>
                {
                    new UserTaskList() { AppUserId = user1Id , TaskListId = "1"},
                    new UserTaskList() { AppUserId = user1Id , TaskListId = "2"},
                    new UserTaskList() { AppUserId = user1Id , TaskListId = "3"},
                    new UserTaskList() { AppUserId = user2Id , TaskListId = "1"},
                });


            var taskLogic = new TaskListLogic(tlMockRepository.Object, utlMockRepository.Object);

            // Act
            var result = await taskLogic.GetAuthorizedTaskListsAsync(user1Id);

            // Assert
            Assert.IsTrue(result.Count() == 3
                && result.Any(t => t.Id == "1" && t.Name == "List 1" && t.Description == "Description 1")
                && result.Any(t => t.Id == "2" && t.Name == "List 2" && t.Description == "Description 2")
                && result.Any(t => t.Id == "3" && t.Name == "List 3" && t.Description == "Description 3")
                );
        }

        [Test]
        public async Task GetTotalWorkTime()
        {
            // Arrange
            var mockRepository = new Mock<IUserWorkLogRepository>();
            mockRepository.Setup(repo => repo.ReadAsync())
                          .ReturnsAsync(new List<UserWorkLog>
                          {
                              new UserWorkLog { AppUserId = "1", TaskItemId = "1", WorkTime = TimeSpan.FromMinutes(60).Ticks },
                              new UserWorkLog { AppUserId = "1", TaskItemId = "2", WorkTime = TimeSpan.FromMinutes(180).Ticks },
                              new UserWorkLog { AppUserId = "1", TaskItemId = "3", WorkTime = TimeSpan.FromMinutes(90).Ticks },
                              new UserWorkLog { AppUserId = "2", TaskItemId = "1", WorkTime = TimeSpan.FromMinutes(60).Ticks },
                          });

            var taskLogic = new UserWorkLogLogic(mockRepository.Object);

            // Act
            var result = await taskLogic.GetTotalWorkTimeAsync("1");

            // Assert
            Assert.That(result, Is.EqualTo(5.5));
        }

        [Test]
        public async Task GetAuthorizedTaskItemsBySpecifiedWorkflow()
        {
            // Arrange
            var tlist = new TaskList()
            {
                Id = "1",
                Name = "List 1",
                Description = "Description 1",
                AssignedMembers = new List<UserTaskList>()
                {
                    new UserTaskList() {AppUserId = "1", TaskListId = "1"},
                    new UserTaskList() {AppUserId = "2", TaskListId = "1"},
                }
            };

            var mockRepository = new Mock<ITaskItemRepository>();
            mockRepository.Setup(repo => repo.ReadAsync())
                          .ReturnsAsync(new List<TaskItem>()
                          {
                              new TaskItem
                              {
                                  Title = "Task 1",
                                  Details = "Description 1",
                                  TaskList = tlist,
                                  WorkflowItems = new List<WorkflowItem>()
                                  {
                                      new WorkflowItem() { Name = "Workflow 1", Order = 100, IsActive = true },
                                      new WorkflowItem() { Name = "Workflow 2", Order = 0, IsActive = false },
                                  }
                              },
                              new TaskItem
                              {
                                  Title = "Task 2",
                                  Details = "Description 2",
                                  TaskList = tlist,
                                  WorkflowItems = new List<WorkflowItem>()
                                  {
                                      new WorkflowItem() { Name = "Workflow 1", Order = 3, IsActive = true },
                                      new WorkflowItem() { Name = "Workflow 2", Order = 0, IsActive = false },
                                  }
                              },
                              new TaskItem
                              {
                                  Title = "Task 3",
                                  Details = "Description 3",
                                  TaskList = tlist,
                                  WorkflowItems = new List<WorkflowItem>()
                                  {
                                      new WorkflowItem() { Name = "Workflow 1", Order = 100, IsActive = true },
                                      new WorkflowItem() { Name = "Workflow 2", Order = 0, IsActive = false },
                                  }
                              },
                          });

            var taskLogic = new TaskItemLogic(mockRepository.Object);

            // Act
            var result = await taskLogic.GetAuthorizedTaskItemsBySpecifiedWorkflowAsync("1", 100);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
        }
    }
}