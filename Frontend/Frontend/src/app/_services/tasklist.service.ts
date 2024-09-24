import { Injectable, inject } from "@angular/core";
import { Observable } from "rxjs";
import { TaskList } from "../_models/tasklistmodel";
import { HttpClient } from "@angular/common/http";
import { APP_URLS } from "../app.urls";
import { TaskListDto } from "../_dtos/taskListDto";
import { TaskItem } from "../_models/taskitemmodel";
import { WorkflowItem } from "../_models/workflowitemmodel";
import { CreateTaskListDto } from "../_dtos/createTaskListDto";
import { UpdateTaskListDto } from "../_dtos/updateTaskListDto";

@Injectable({
    providedIn: 'root'
})
export class TaskListService{
    private http = inject(HttpClient)
    
    //=====================
    //=====================
    // HTTP Methods
    //=====================
    //=====================

    public getTaskListDto(id: string) : Observable<TaskListDto>{
        let response = this.http.get<TaskListDto>(
            APP_URLS.baseUrl + APP_URLS.taskLists + id,
        )
        return response
    }

    public getTaskListDtos() : Observable<Array<TaskListDto>>{
        let response = this.http.get<Array<TaskListDto>>(
            APP_URLS.baseUrl + APP_URLS.taskLists,
        )
        return response
    }

    public createTaskList(createTaskListDto: CreateTaskListDto) : Observable<TaskListDto>{    
        let response = this.http.post<TaskListDto>(
            APP_URLS.baseUrl + APP_URLS.taskLists, 
            createTaskListDto,
        )
        return response
    }

    public deleteTaskList(listId: string) : Observable<Object>{
        let response = this.http.delete(
            APP_URLS.baseUrl + APP_URLS.taskLists + listId,
        )
        return response
    }

    public updateTaskList(taskListDto: UpdateTaskListDto): Observable<TaskListDto>{
        let response = this.http.put<TaskListDto>(
            APP_URLS.baseUrl + APP_URLS.taskLists,
            taskListDto
        )
        return response
    }

    //=====================
    //=====================
    // MAPPERS
    //=====================
    //=====================

    public mapTaskListArrayFromDtos(dtos: Array<TaskListDto>) : Array<TaskList>{
        let taskLists: Array<TaskList> = []
        dtos.map(x => {
            let list = this.mapTaskListFromDto(x)
            taskLists.push(list)
        })
        return taskLists
    }

    public mapTaskListFromDto(dto: TaskListDto) : TaskList{
        let list = new TaskList()
        list.id = dto.id
        list.name = dto.name
        list.description = dto.description
        list.assignedMembers = dto.assignedMembers
        list.creator = dto.creator

        for (let i = 0; i < dto.tasks.length; i++) {
            const temp = dto.tasks[i];
            let task = new TaskItem
            task.id = temp.id
            task.title = temp.title
            task.details = temp.details
            task.createdAt = temp.createdAt
            task.updatedAt = temp.updatedAt
            task.deadline = temp.deadline
            task.priority = temp.priority
            task.taskListId = temp.taskListId
            task.assignee = temp.assignee
            task.creator = temp.creator
            for (let j = 0; j < temp.workflowItems.length; j++) {
                const tempWorkflowItem = temp.workflowItems[j];
                let workflow = new WorkflowItem()
                workflow.id = tempWorkflowItem.id
                workflow.name = tempWorkflowItem.name
                workflow.isActive = tempWorkflowItem.isActive
                workflow.colorCode = tempWorkflowItem.colorCode
                workflow.isDeletable = tempWorkflowItem.isDeletable
                workflow.order = tempWorkflowItem.order
                workflow.taskItemId = tempWorkflowItem.taskItemId
                task.workflowItems.push(workflow)
            }
            list.tasks.push(task)
        }
        return list
    }

    public mapTaskListFromTaskList(mapTo: TaskList, mapFrom: TaskList): void{
        mapTo.id = mapFrom.id
        mapTo.name = mapFrom.name
        mapTo.description = mapFrom.description
        mapTo.isDeleted = mapFrom.isDeleted
        mapTo.deletedOn = mapFrom.deletedOn
        mapTo.creator = mapFrom.creator
        mapTo.assignedMembers = mapFrom.assignedMembers
        mapTo.tasks = mapFrom.tasks
    }

    public mapUpdateTaskListDto(taskList: TaskList) : UpdateTaskListDto{
        let dto = new UpdateTaskListDto()
        dto.id = taskList.id
        dto.name = taskList.name
        dto.description = taskList.description
        dto.assignedMembers = taskList.assignedMembers
        return dto
    }
    
}