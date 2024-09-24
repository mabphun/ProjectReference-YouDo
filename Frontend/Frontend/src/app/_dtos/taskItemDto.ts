import { ChangeLog } from "../_models/changelogmodel"
import { WorkflowItem } from "../_models/workflowitemmodel"
import { AppUserDto } from "./appUserDto"
import { TaskListDto } from "./taskListDto"
import { UserWorkLogDto } from "./userWorkLogDto"

export class TaskItemDto{
    public id: string = ''
    public title: string = ''
    public details: string = ''
    public priority: number = 1
    public deadline: string = ''
    public estimated: number = 0
    public createdAt: string = ''
    public updatedAt: string = ''
    public creator: AppUserDto = new AppUserDto()
    public assignee: AppUserDto = new AppUserDto()
    public workflowItems: Array<WorkflowItem> = []
    public userWorkLogs: Array<UserWorkLogDto> = []
    public changeLogs: Array<ChangeLog> = []
    public taskListId: string = ''
    public taskList: TaskListDto = new TaskListDto()
}

/*
{
      "id": "string",
      "title": "string",
      "details": "string",
      "priority": 0,
      "deadline": "2024-03-14T11:52:18.324Z",
      "createdAt": "2024-03-14T11:52:18.324Z",
      "updatedAt": "2024-03-14T11:52:18.324Z",
      "creator": {
        "id": "string",
        "userName": "string",
        "image": "string",
        "firstName": "string",
        "lastName": "string"
      },
      "assignee": {
        "id": "string",
        "userName": "string",
        "image": "string",
        "firstName": "string",
        "lastName": "string"
      },
      "currentWorkflow": {
        "id": "string",
        "name": "string",
        "order": 0,
        "isActive": true,
        "taskItemId": "string"
      }
    }
*/