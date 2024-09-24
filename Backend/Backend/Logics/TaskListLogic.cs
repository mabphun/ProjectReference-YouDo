using Backend.Data;
using Backend.DTOs;
using Backend.Models;

namespace Backend.Logics
{
    public class TaskListLogic : ITaskListLogic
    {
        private readonly ITaskListRepository _taskListRepo;
        private readonly IUserTaskListRepository _userTaskListRepo;

        public TaskListLogic(ITaskListRepository repo, IUserTaskListRepository userTaskListRepo)
        {
            _taskListRepo = repo;
            _userTaskListRepo = userTaskListRepo;
        }

        public async Task<TaskList> CreateAsync(CreateTaskListDto createDto)
        {
            // Validations can be here
            var resp = await _taskListRepo.CreateAsync(createDto);
            return resp;
        }

        public async Task<IEnumerable<TaskList>> ReadAsync()
        {
            return await _taskListRepo.ReadAsync();
        }

        public async Task<TaskList> ReadAsync(string id)
        {
            return await _taskListRepo.ReadAsync(id);
        }

        public async Task DeleteAsync(string id, string callerId)
        {
            await _taskListRepo.DeleteAsync(id, callerId);
        }

        public async Task<TaskList> UpdateAsync(UpdateTaskListDto taskListDto)
        {
            var updatedList = await _taskListRepo.UpdateAsync(taskListDto);
            return updatedList;
        }

        public async Task<IEnumerable<TaskList>> GetAuthorizedTaskListsAsync(string userId)
        {
            var userTaskLists = await _userTaskListRepo.ReadAsync();
            var listIds = userTaskLists
                .Where(x => x.AppUserId == userId)
                .Select(x => x.TaskListId)
                .ToList();

            var lists = await _taskListRepo.ReadAsync();

            var result = lists.Where(x => listIds.Contains(x.Id));

            return result;
        }

        public async Task<TaskList> GetAuthorizedTaskListAsync(string userId, string listId)
        {
            var userTaskLists = await _userTaskListRepo.ReadAsync();
            var list = userTaskLists
                .Where(x => x.AppUserId == userId && x.TaskListId == listId)
                .Select(x=> x.TaskList)
                .FirstOrDefault();

            if (list == null)
            {
                throw new InvalidOperationException("You are unauthorized to see this list.");
            }

            return list;
        }
    }
}
