import { HttpClient } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import { CreateWorkflowItemDto } from "../_dtos/createWorkflowItemDto";
import { Observable } from "rxjs";
import { APP_URLS } from "../app.urls";
import { WorkflowItem } from "../_models/workflowitemmodel";

@Injectable({
    providedIn: 'root'
})
export class WorkflowItemService{
    private http = inject(HttpClient)


    public createWorkflowItems(createDtos: Array<CreateWorkflowItemDto>) : Observable<object>{
        let response = this.http.post(
            APP_URLS.baseUrl + APP_URLS.workflowItem + 'mul/',
            createDtos
        )
        return response
    }

    public updateWorkflowItems(updateDtos: Array<WorkflowItem>) : Observable<object>{
        let response = this.http.put(
            APP_URLS.baseUrl + APP_URLS.workflowItem + 'mul/',
            updateDtos
        )
        return response
    }

    public deleteWorkflowItem(id: string) : Observable<object>{
        let response = this.http.delete(
            APP_URLS.baseUrl + APP_URLS.workflowItem + id,
        )
        return response
    }
}