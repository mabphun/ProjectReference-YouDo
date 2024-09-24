import { HttpClient } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import { TaskItem } from "../_models/taskitemmodel";
import { CreateChangeLogDto } from "../_dtos/createChangeLogDto";
import { ApiService } from "./api.service";
import { ChangeLog } from "../_dtos/changeLogDto";
import { Observable } from "rxjs";
import { APP_URLS } from "../app.urls";
import { DateConverter } from "./date.converter";

@Injectable({
    providedIn: 'root'
})
export class ChangeLogService{
    http = inject(HttpClient)
    api = inject(ApiService)
    dateConverter = inject(DateConverter)

    public createChangeLog(changeLog: CreateChangeLogDto) : Observable<ChangeLog>{
        let response = this.http.post<ChangeLog>(
            APP_URLS.baseUrl + APP_URLS.changeLog,
            changeLog,
        )
        return response
    }


    public isSomethingChangedInDto(changelog: ChangeLog) : boolean{
        if (changelog.oldTitle !== changelog.newTitle) return true
        if (changelog.oldDetails !== changelog.newDetails) return true
        if (changelog.oldPriority !== changelog.newPriority) return true
        if (changelog.oldAssignee.id !== changelog.newAssignee.id) return true
        if (changelog.oldDeadline !== changelog.newDeadline) return true
        if (changelog.oldWorkflowItem.id !== changelog.newWorkflowItem.id) return true
        return false
    }

    public isSomethingChangedInCreateDto(changelog: CreateChangeLogDto) : boolean{
        if (changelog.oldTitle !== changelog.newTitle) return true
        if (changelog.oldDetails !== changelog.newDetails) return true
        if (changelog.oldPriority !== changelog.newPriority) return true
        if (changelog.oldAssigneeId !== changelog.newAssigneeId) return true
        if (changelog.oldDeadline !== changelog.newDeadline) return true
        if (changelog.oldWorkflowItem.id !== changelog.newWorkflowItem.id) return true
        return false
    }


    //MAPPERS

    mapChangeLog(r: ChangeLog){
        let newChangeLog = new ChangeLog()
            newChangeLog.id = r.id
            newChangeLog.changer = r.changer
            newChangeLog.changeDate = r.changeDate
            newChangeLog.taskItemId = r.taskItemId

            newChangeLog.oldTitle = r.oldTitle
            newChangeLog.oldDetails = r.oldDetails
            newChangeLog.oldDeadline = r.oldDeadline
            newChangeLog.oldAssigneeId = r.oldAssigneeId
            newChangeLog.oldAssignee = r.oldAssignee
            newChangeLog.oldPriority = r.oldPriority
            newChangeLog.oldWorkflowItem = r.oldWorkflowItem

            newChangeLog.newTitle = r.newTitle
            newChangeLog.newDetails = r.newDetails
            newChangeLog.newDeadline = r.newDeadline
            newChangeLog.newAssigneeId = r.newAssigneeId
            newChangeLog.newAssignee = r.newAssignee
            newChangeLog.newPriority = r.newPriority
            newChangeLog.newWorkflowItem = r.newWorkflowItem
    }

    public mapCreateChangeLogDto(oldItem: TaskItem, newItem: TaskItem) : CreateChangeLogDto{
        let changeLog = new CreateChangeLogDto()
        changeLog.taskItemId = oldItem.id
        changeLog.changerId = this.api.getUserId()
    
        changeLog.oldTitle = oldItem.title
        changeLog.oldDetails = oldItem.details
        changeLog.oldDeadline = this.dateConverter.momentRef.utc(oldItem.deadline).toJSON()
        changeLog.oldAssigneeId = oldItem.assignee.id
        changeLog.oldPriority = oldItem.priority.toString()
        changeLog.oldWorkflowItem = oldItem.getCurrentWorkflowItem()
    
        changeLog.newTitle = newItem.title
        changeLog.newDetails = newItem.details
        changeLog.newDeadline = this.dateConverter.StringToUtcMomentJson(newItem.deadline)
        changeLog.newAssigneeId = newItem.assignee.id
        changeLog.newPriority = newItem.priority.toString()
        changeLog.newWorkflowItem = newItem.getCurrentWorkflowItem()
    
        return changeLog
      }
    
}