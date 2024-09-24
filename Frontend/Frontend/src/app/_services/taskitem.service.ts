import { Injectable, inject } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { APP_URLS } from "../app.urls";
import { WorkflowItem } from "../_models/workflowitemmodel";
import { TaskItemDto } from "../_dtos/taskItemDto";
import { TaskItem } from "../_models/taskitemmodel";
import { CreateTaskItemDto } from "../_dtos/createTaskItemDto";
import { UpdateTaskItemDto } from "../_dtos/updateTaskItemDto";
import { DateConverter } from "./date.converter";
import { ChangeLog } from "../_models/changelogmodel";
import { ApiService } from "./api.service";

@Injectable({
    providedIn: 'root'
})
export class TaskItemService{
    private http = inject(HttpClient)
    private api = inject(ApiService)
    private dateConverter = inject(DateConverter)
    

    //=====================
    //=====================
    // HTTP Methods
    //=====================
    //=====================

    public getTaskItemDto(id: string) : Observable<TaskItemDto>{
        let response = this.http.get<TaskItemDto>(
          APP_URLS.baseUrl + APP_URLS.taskItem + id
        )
        return response
    }

    public getCreatedTaskItems() : Observable<Array<TaskItemDto>>{
      let userid = this.api.getUserId()
      let response = this.http.get<Array<TaskItemDto>>(
        APP_URLS.baseUrl + APP_URLS.taskItem + 'c/' + userid
      )
      return response
    }

    public createTaskItem(createTaskItemDto: CreateTaskItemDto) : 
    Observable<TaskItemDto>{    
      let response = this.http.post<TaskItemDto>(
        APP_URLS.baseUrl + APP_URLS.taskItem, 
        createTaskItemDto,
      )
      return response
    }

    public deleteTaskItem(taskId: string) : Observable<Object>{
      let response = this.http.delete(
        APP_URLS.baseUrl + APP_URLS.taskItem + taskId,
      )
      return response
    }

    public updateTaskItem(updateTaskItemDto: UpdateTaskItemDto) : Observable<TaskItemDto>{
      let response = this.http.put<TaskItemDto>(
        APP_URLS.baseUrl + APP_URLS.taskItem,
        updateTaskItemDto
      )
      return response
    }

    //=====================
    //=====================
    // MAPPERS
    //=====================
    //=====================

    public mapTaskItemFromTaskItem(mapTo: TaskItem, mapFrom: TaskItem) : void{
      mapTo.id = mapFrom.id
      mapTo.title = mapFrom.title
      mapTo.details = mapFrom.details
      mapTo.createdAt = mapFrom.createdAt
      mapTo.updatedAt = mapFrom.updatedAt
      mapTo.deadline = mapFrom.deadline
      mapTo.priority = mapFrom.priority    
      mapTo.taskListId = mapFrom.taskListId
      mapTo.assigneeId = mapFrom.assigneeId
      mapTo.assignee = mapFrom.assignee
      mapTo.creatorId = mapFrom.creatorId
      mapTo.creator = mapFrom.creator
      mapTo.taskList.creator = mapFrom.taskList.creator
      mapTo.taskList.assignedMembers = mapFrom.taskList.assignedMembers
      mapTo.taskList.id = mapFrom.taskList.id
      mapTo.workflowItems = []
      for (let j = 0; j < mapFrom.workflowItems.length; j++) {
        const tempWorkflowItem = mapFrom.workflowItems[j];
        let workflow = new WorkflowItem()
        workflow.id = tempWorkflowItem.id
        workflow.name = tempWorkflowItem.name
        workflow.isActive = tempWorkflowItem.isActive
        workflow.colorCode = tempWorkflowItem.colorCode
        workflow.isDeletable = tempWorkflowItem.isDeletable
        workflow.order = tempWorkflowItem.order
        workflow.taskItemId = tempWorkflowItem.taskItemId
        mapTo.workflowItems.push(workflow)
      }
      mapTo.workflowItems.sort((x, y) => x.order - y.order)

      mapTo.userWorkLogs = []
      for (let j = 0; j < mapFrom.userWorkLogs.length; j++) {
        const uwlDto = mapFrom.userWorkLogs[j];
        mapTo.userWorkLogs.push(uwlDto)        
      }
    }

    public mapTaskItemFromDto(mapFrom: TaskItemDto) : TaskItem{
      let mapTo = new TaskItem()
      mapTo.id = mapFrom.id
      mapTo.title = mapFrom.title
      mapTo.details = mapFrom.details
      mapTo.estimated = mapFrom.estimated
      mapTo.createdAt = mapFrom.createdAt
      mapTo.updatedAt = mapFrom.updatedAt
      mapTo.deadline = mapFrom.deadline
      mapTo.priority = mapFrom.priority    
      mapTo.taskListId = mapFrom.taskListId
      mapTo.assigneeId = mapFrom.assignee.id
      mapTo.assignee = mapFrom.assignee
      mapTo.creatorId = mapFrom.creator.id
      mapTo.creator = mapFrom.creator
      mapTo.taskList.creator = mapFrom.taskList.creator
      mapTo.taskList.assignedMembers = mapFrom.taskList.assignedMembers
      mapTo.taskList.id = mapFrom.taskList.id
      mapTo.workflowItems = []
      for (let j = 0; j < mapFrom.workflowItems.length; j++) {
        const tempWorkflowItem = mapFrom.workflowItems[j];
        let workflow = new WorkflowItem()
        workflow.id = tempWorkflowItem.id
        workflow.name = tempWorkflowItem.name
        workflow.isActive = tempWorkflowItem.isActive
        workflow.colorCode = tempWorkflowItem.colorCode
        workflow.isDeletable = tempWorkflowItem.isDeletable
        workflow.order = tempWorkflowItem.order
        workflow.taskItemId = tempWorkflowItem.taskItemId
        mapTo.workflowItems.push(workflow)
      }
      mapTo.workflowItems.sort((x, y) => x.order - y.order)
  
      mapTo.userWorkLogs = []
      for (let j = 0; j < mapFrom.userWorkLogs.length; j++) {
        const uwlDto = mapFrom.userWorkLogs[j];
        mapTo.userWorkLogs.push(uwlDto)        
      }

      mapTo.changeLogs = []
      for (let j = 0; j < mapFrom.changeLogs.length; j++) {
        const tempChangeLog = mapFrom.changeLogs[j];
        let changeLog = new ChangeLog()
        changeLog.id = tempChangeLog.id
        changeLog.changer = tempChangeLog.changer
        changeLog.changeDate = tempChangeLog.changeDate
        changeLog.taskItemId = tempChangeLog.taskItemId
  
        changeLog.oldTitle = tempChangeLog.oldTitle
        changeLog.oldDetails = tempChangeLog.oldDetails
        changeLog.oldDeadline = tempChangeLog.oldDeadline
        changeLog.oldAssigneeId = tempChangeLog.oldAssigneeId
        changeLog.oldAssignee = tempChangeLog.oldAssignee
        changeLog.oldPriority = tempChangeLog.oldPriority
        changeLog.oldWorkflowItem = tempChangeLog.oldWorkflowItem
  
        changeLog.newTitle = tempChangeLog.newTitle
        changeLog.newDetails = tempChangeLog.newDetails
        changeLog.newDeadline = tempChangeLog.newDeadline
        changeLog.newAssigneeId = tempChangeLog.newAssigneeId
        changeLog.newAssignee = tempChangeLog.newAssignee
        changeLog.newPriority = tempChangeLog.newPriority
        changeLog.newWorkflowItem = tempChangeLog.newWorkflowItem
        mapTo.changeLogs.push(changeLog)
      }
      let moment = this.dateConverter.momentRef
      mapTo.changeLogs.sort(function (left, right) {
        return moment.utc(right.changeDate).diff(moment.utc(left.changeDate))
      })

      return mapTo
    }

    public createUpdateTaskItemDto(task: TaskItem): UpdateTaskItemDto{
      let updateDto = new UpdateTaskItemDto()
      updateDto.id = task.id
      updateDto.assigneeId = task.assignee.id
      updateDto.details = task.details
      updateDto.title = task.title
      updateDto.priority = task.priority.toString()
      task.workflowItems.forEach(x=> updateDto.workflowItems.push(x))
      
      if (this.dateConverter.momentRef.isMoment(task.deadline)){
        updateDto.deadline = task.deadline
      }
      else{
        updateDto.deadline = this.dateConverter.StringToUtcMomentJson(task.deadline)
      }

      return updateDto
    }
    
}