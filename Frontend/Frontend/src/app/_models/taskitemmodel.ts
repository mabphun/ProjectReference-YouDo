import { AppUserDto } from "../_dtos/appUserDto"
import { UserWorkLogDto } from "../_dtos/userWorkLogDto"
import { ChangeLog } from "./changelogmodel"
import { TaskList } from "./tasklistmodel"
import { TaskItemPriority } from "./tasklistpriority"
import { WorkflowItem } from "./workflowitemmodel"

export class TaskItem {
    public id: string = ""
    public title: string = ""
    public details: string = ""
    public priority: TaskItemPriority = TaskItemPriority.Normal
    public deadline: string = ""
    public estimated: number = 0
    public createdAt: string = ""
    public updatedAt: string = ""
    public creator: AppUserDto = new AppUserDto()
    public creatorId: string = ""
    public assignee: AppUserDto = new AppUserDto()
    public assigneeId: string = ""
    public workflowItems: Array<WorkflowItem> = []
    public userWorkLogs: Array<UserWorkLogDto> = []
    public changeLogs: Array<ChangeLog> = []
    public taskListId: string = ""
    public taskList: TaskList = new TaskList()



    public getCurrentWorkflow() : string{
      let currentWorkflow = this.workflowItems.find((items)=> items.isActive)
      return currentWorkflow !== undefined ? currentWorkflow.name : "Undefined"
    }
  
    public getCurrentWorkflowItem() : WorkflowItem{
      let currentWorkflow = this.workflowItems.find((items)=> items.isActive)
      return currentWorkflow !== undefined ? currentWorkflow : new WorkflowItem()
    }
}




/* 
"tasks": [
      {
        "id": "string",
        "title": "string",
        "details": "string",
        "priority": 0,
        "deadline": "2024-03-01T11:44:03.228Z",
        "createdAt": "2024-03-01T11:44:03.228Z",
        "updatedAt": "2024-03-01T11:44:03.228Z",
        "creatorId": "string",
        "assigneeId": "string",
        "taskListId": "string"
      }
*/