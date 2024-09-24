using Backend.Data;
using Backend.DTOs;
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
    public class CRUDTests
    {
        [Test]
        public async Task GetAllTasks()
        {
            // Arrange
            var mockRepository = new Mock<ITaskItemRepository>();
            mockRepository.Setup(repo => repo.ReadAsync())
                .ReturnsAsync(new List<TaskItem>
                {
                    new TaskItem { Id = "1", Title = "Task 1", Details = "Description 1" },
                    new TaskItem { Id = "2", Title = "Task 2", Details = "Description 2" },
                    new TaskItem { Id = "3", Title = "Task 3", Details = "Description 3" }
                });

            var taskLogic = new TaskItemLogic(mockRepository.Object);

            // Act
            var result = await taskLogic.ReadAsync();
            
            // Assert
            Assert.IsTrue(
                   result.Any(t => t.Id == "1" && t.Title == "Task 1" && t.Details == "Description 1") 
                && result.Any(t => t.Id == "2" && t.Title == "Task 2" && t.Details == "Description 2")
                && result.Any(t => t.Id == "3" && t.Title == "Task 3" && t.Details == "Description 3")
                );
        }

        [Test]
        public async Task GetTaskById()
        {
            // Arrange
            string taskIdToRetrieve = "2";
            var expectedTask = new TaskItem { Id = taskIdToRetrieve, Title = "Task 2", Details = "Description 2" };

            var mockRepository = new Mock<ITaskItemRepository>();
            mockRepository.Setup(repo => repo.ReadAsync(taskIdToRetrieve))
                          .ReturnsAsync(expectedTask);

            var taskLogic = new TaskItemLogic(mockRepository.Object);

            // Act
            var result = await taskLogic.ReadAsync(taskIdToRetrieve);

            // Assert
            Assert.IsTrue(expectedTask.Id == result.Id
                && expectedTask.Title == result.Title
                && expectedTask.Details == result.Details
                );
        }

        [Test]
        public async Task CreateTask()
        {
            // Arrange
            var createTaskDto = new CreateTaskItemDto() { Title = "Task 4 ", Details = "Description 2" };

            var mockRepository = new Mock<ITaskItemRepository>();
            mockRepository.Setup(repo => repo.CreateAsync(createTaskDto))
                          .ReturnsAsync(new TaskItem() 
                          {
                              Title = createTaskDto.Title, 
                              Details = createTaskDto.Details 
                          });

            var taskLogic = new TaskItemLogic(mockRepository.Object);

            // Act
            var result = await taskLogic.CreateAsync(createTaskDto);

            // Assert
            Assert.IsTrue(createTaskDto.Title == result.Title && createTaskDto.Details == result.Details);
        }

        [Test]
        public async Task UpdateTask()
        {
            // Arrange
            var updateTaskDto = new UpdateTaskItemDto() { Title = "Task 4 ", Details = "Description 2" };

            var mockRepository = new Mock<ITaskItemRepository>();
            mockRepository.Setup(repo => repo.UpdateAsync(updateTaskDto))
                          .ReturnsAsync(new TaskItem() 
                          { 
                              Title = updateTaskDto.Title, 
                              Details = updateTaskDto.Details 
                          });

            var taskLogic = new TaskItemLogic(mockRepository.Object);

            // Act
            var result = await taskLogic.UpdateAsync(updateTaskDto);

            // Assert
            Assert.IsTrue(updateTaskDto.Title == result.Title && updateTaskDto.Details == result.Details);
        }

        [Test]
        public async Task DeleteTask()
        {
            // Arrange
            string taskIdToDelete = "1";

            var mockRepository = new Mock<ITaskItemRepository>();
            mockRepository.Setup(repo => repo.DeleteAsync(taskIdToDelete))
                          .Returns(Task.CompletedTask);
                          
            var taskLogic = new TaskItemLogic(mockRepository.Object);

            // Act
            var result = taskLogic.DeleteAsync(taskIdToDelete).IsCompletedSuccessfully;

            // Assert
            Assert.IsTrue(result);
        }
    }
}
