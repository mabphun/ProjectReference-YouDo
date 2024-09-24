using Backend.Data;
using Backend.Models;

namespace Backend.Logics
{
    public class UserTaskListLogic : IUserTaskListLogic
    {
        private readonly IUserTaskListRepository _userWorkLogRepo;

        public UserTaskListLogic(IUserTaskListRepository repo)
        {
            _userWorkLogRepo = repo;
        }

        public async Task CreateAsync(UserTaskList userTaskList)
        {
            // Validations can be here
            await _userWorkLogRepo.CreateAsync(userTaskList);
        }

        public async Task<IEnumerable<UserTaskList>> ReadAsync()
        {
            return await _userWorkLogRepo.ReadAsync();
        }

        public async Task<UserTaskList> ReadAsync(string appUserId, string taskListId)
        {
            return await _userWorkLogRepo.ReadAsync(appUserId, taskListId);
        }

        public async Task DeleteAsync(string appUserId, string taskListId)
        {
            try
            {
                await _userWorkLogRepo.DeleteAsync(appUserId, taskListId);
            }
            catch(ArgumentException e)
            {
                throw new ArgumentException(e.Message);
            }
            catch (BadHttpRequestException e)
            {
                throw new BadHttpRequestException(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //public void Update(UserTaskList userTaskList)
        //{
        //    _userWorkLogRepo.Update(userTaskList);
        //}
    }
}
