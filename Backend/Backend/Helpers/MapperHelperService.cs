using Backend.DTOs;
using Backend.Models;

namespace Backend.Helpers
{
    public class MapperHelperService
    {
        #region AppUser;

        public AppUserDto MapAppUserDtoFromAppUser(AppUser user)
        {
            var dto = new AppUserDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Image = user.Image,
            };
            return dto;
        }

        #endregion;

        #region UserWorkLog;

        public UserWorkLogDto MapUsersWorkLogsForStatistics(UserWorkLog uwl)
        {
            var dto = new UserWorkLogDto();
            dto.WorkTimeInMins = TimeSpan.FromTicks(uwl.WorkTime).TotalMinutes;
            dto.AppUser = MapAppUserDtoFromAppUser(uwl.AppUser);
            dto.LogDate = uwl.LogDate;
            dto.TaskItem = new TaskItemDto()
            {
                Id = uwl.TaskItem.Id,
                Title = uwl.TaskItem.Title,
            };
            return dto;
        }

        public UserWorkLogDto MapUserWorkLogDtoFromUserWorkLog(UserWorkLog uwl)
        {
            UserWorkLogDto dto = new UserWorkLogDto();
            dto.WorkTimeInMins = TimeSpan.FromTicks(uwl.WorkTime).TotalMinutes;
            dto.LogDate = DateTime.UtcNow;

            var appUser = new AppUserDto()
            {
                Id = uwl.AppUser.Id,
                FirstName = uwl.AppUser.FirstName,
                LastName = uwl.AppUser.LastName,
                UserName = uwl.AppUser.UserName,
                Image = uwl.AppUser.Image,
            };
            dto.AppUser = appUser;

            return dto;
        }

        #endregion;

        #region TaskItem;

        public TaskItemDto MapTaskItemDtoFromTaskItem(TaskItem taskItem)
        {
            TaskItemDto itemDto = new TaskItemDto()
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Details = taskItem.Details,
                Deadline = taskItem.Deadline,
                Estimated = taskItem.Estimated,
                Priority = taskItem.Priority,
                WorkflowItems = taskItem.WorkflowItems,
                CreatedAt = taskItem.CreatedAt,
                UpdatedAt = taskItem.UpdatedAt,
                TaskListId = taskItem.TaskListId,
            };

            itemDto.UserWorkLogs = new List<UserWorkLogDto>();
            foreach (var userworklog in taskItem.LoggedWork)
            {
                UserWorkLogDto userWorkLogDto = new UserWorkLogDto()
                {
                    WorkTimeInMins = TimeSpan.FromTicks(userworklog.WorkTime).TotalMinutes,
                };
                userWorkLogDto.AppUser = new AppUserDto()
                {
                    Id = userworklog.AppUser.Id,
                    FirstName = userworklog.AppUser.FirstName,
                    LastName = userworklog.AppUser.LastName,
                    UserName = userworklog.AppUser.UserName,
                    Image = userworklog.AppUser.Image,
                };
                itemDto.UserWorkLogs.Add(userWorkLogDto);
            }

            itemDto.ChangeLogs = new List<ChangeLogDto>();
            foreach (var changeLog in taskItem.ChangeLogs)
            {
                ChangeLogDto changeLogDto = new ChangeLogDto()
                {
                    Id = changeLog.Id,
                    ChangeDate = changeLog.ChangeDate,
                    TaskItemId = changeLog.TaskItemId,

                    OldTitle = changeLog.OldTitle,
                    OldDetails = changeLog.OldDetails,
                    OldPriority = changeLog.OldPriority.ToString(),
                    OldDeadline = changeLog.OldDeadline.ToString(),
                    OldAssigneeId = changeLog.OldAssigneeId,
                    NewTitle = changeLog.NewTitle,
                    NewDetails = changeLog.NewDetails,
                    NewPriority = changeLog.NewPriority.ToString(),
                    NewDeadline = changeLog.NewDeadline.ToString(),
                    NewAssigneeId = changeLog.NewAssigneeId,
                };
                var oldWorkflowItem = changeLog.TaskItem.WorkflowItems.FirstOrDefault(x => changeLog.OldWorkflowItemId == x.Id);
                if (oldWorkflowItem == null) throw new ArgumentException("Error! Couldn't find Old WorkflowItem!");
                changeLogDto.OldWorkflowItem = oldWorkflowItem;

                var newWorkflowItem = changeLog.TaskItem.WorkflowItems.FirstOrDefault(x => changeLog.NewWorkflowItemId == x.Id);
                if (newWorkflowItem == null) throw new ArgumentException("Error! Couldn't find New WorkflowItem!");
                changeLogDto.NewWorkflowItem = newWorkflowItem;

                var changerUser = changeLog.TaskItem.TaskList.AssignedMembers
                    .Where(x => x.AppUserId == changeLog.ChangerId)
                    .Select(x => x.AppUser)
                    .FirstOrDefault();
                if (changerUser == null) throw new ArgumentException("Error! Couldn't find Changer User!");

                var changerUserDto = new AppUserDto()
                {
                    Id = changerUser.Id,
                    FirstName = changerUser.FirstName,
                    LastName = changerUser.LastName,
                    UserName = changerUser.UserName,
                    Image = changerUser.Image,
                };
                changeLogDto.Changer = changerUserDto;

                var oldAssignee = changeLog.TaskItem.TaskList.AssignedMembers
                    .Where(x => x.AppUserId == changeLog.OldAssigneeId)
                    .Select(x => x.AppUser)
                    .FirstOrDefault();
                if (oldAssignee == null) throw new ArgumentException("Error! Couldn't find Changer User!");
                var oldAssigneeDto = new AppUserDto()
                {
                    Id = oldAssignee.Id,
                    FirstName = oldAssignee.FirstName,
                    LastName = oldAssignee.LastName,
                    UserName = oldAssignee.UserName,
                    Image = oldAssignee.Image,
                };
                changeLogDto.OldAssignee = oldAssigneeDto;

                var newAssignee = changeLog.TaskItem.TaskList.AssignedMembers
                    .Where(x => x.AppUserId == changeLog.NewAssigneeId)
                    .Select(x => x.AppUser)
                    .FirstOrDefault();
                if (newAssignee == null) throw new ArgumentException("Error! Couldn't find Changer User!");
                var newAssigneeDto = new AppUserDto()
                {
                    Id = newAssignee.Id,
                    FirstName = newAssignee.FirstName,
                    LastName = newAssignee.LastName,
                    UserName = newAssignee.UserName,
                    Image = newAssignee.Image,
                };
                changeLogDto.NewAssignee = newAssigneeDto;

                itemDto.ChangeLogs.Add(changeLogDto);
            }
            var assigneeAppUser = taskItem.TaskList.AssignedMembers
                .Where(x => x.AppUserId == taskItem.AssigneeId)
                .Select(x => x.AppUser)
                .FirstOrDefault();
            if (assigneeAppUser == null) throw new ArgumentException("Error! Couldn't find assignee!");
            var assignee = new AppUserDto()
            {
                Id = assigneeAppUser.Id,
                UserName = assigneeAppUser.UserName,
                FirstName = assigneeAppUser.FirstName,
                LastName = assigneeAppUser.LastName,
                Image = assigneeAppUser.Image,
            };
            var creatorAppUser = taskItem.TaskList.AssignedMembers
                .Where(x => x.AppUserId == taskItem.CreatorId)
                .Select(x => x.AppUser)
                .FirstOrDefault();
            if (creatorAppUser == null) throw new ArgumentException("Error! Couldn't find creator!");
            var creator = new AppUserDto()
            {
                Id = creatorAppUser.Id,
                UserName = creatorAppUser.UserName,
                FirstName = creatorAppUser.FirstName,
                LastName = creatorAppUser.LastName,
                Image = creatorAppUser.Image,
            };
            itemDto.Assignee = assignee;
            itemDto.Creator = creator;

            var tasklist = new TaskListDto()
            {
                Id = taskItem.TaskList.Id,
                AssignedMembers = new List<AppUserDto>()
            };
            var taskListCreatorAppUser = taskItem.TaskList.AssignedMembers
                    .Where(x => x.AppUserId == taskItem.TaskList.CreatorId)
                    .Select(x => x.AppUser)
                    .FirstOrDefault();
            if (taskListCreatorAppUser == null) throw new ArgumentException("Couldn't find Creator of Task List");
            var listCreator = new AppUserDto()
            {
                Id = taskListCreatorAppUser.Id,
                UserName = taskListCreatorAppUser.UserName,
                FirstName = taskListCreatorAppUser.FirstName,
                LastName = taskListCreatorAppUser.LastName,
                Image = taskListCreatorAppUser.Image,
            };
            tasklist.Creator = listCreator;
            foreach (var item in taskItem.TaskList.AssignedMembers)
            {
                var member = new AppUserDto()
                {
                    Id = item.AppUser.Id,
                    FirstName = item.AppUser.FirstName,
                    LastName = item.AppUser.LastName,
                    Image = item.AppUser.Image,
                    UserName = item.AppUser.UserName,
                };
                tasklist.AssignedMembers.Add(member);
            }
            itemDto.TaskList = tasklist;

            return itemDto;
        }

        #endregion;

        #region TaskList;

        public TaskListDto MapTaskListDtoFromTaskList(TaskList taskList)
        {
            var dto = new TaskListDto()
            {
                Id = taskList.Id,
                Name = taskList.Name,
                Description = taskList.Description,
                AssignedMembers = new List<AppUserDto>(),
                Tasks = new List<TaskItemDto>()
            };

            var taskListCreatorAppUser = taskList.AssignedMembers
                    .Where(x => x.AppUserId == taskList.CreatorId)
                    .Select(x => x.AppUser)
                    .FirstOrDefault();
            if (taskListCreatorAppUser == null) throw new ArgumentException("Couldn't find Creator of Task List");
            var listCreator = MapAppUserDtoFromAppUser(taskListCreatorAppUser);
            dto.Creator = listCreator;

            foreach (var item in taskList.AssignedMembers)
            {
                var member = MapAppUserDtoFromAppUser(item.AppUser);
                dto.AssignedMembers.Add(member);
            }

            foreach (var task in taskList.Tasks)
            {
                var taskdto = MapTaskItemDtoFromTaskItem(task);
                dto.Tasks.Add(taskdto);
            }

            return dto;
        }

            #endregion;
        }
}
