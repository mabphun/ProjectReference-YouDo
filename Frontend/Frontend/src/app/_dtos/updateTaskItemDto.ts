import { WorkflowItem } from "../_models/workflowitemmodel"

export class UpdateTaskItemDto {
    public id: string = ''
    public title: string = ''
    public details: string = ''
    public priority: string = '1'
    public deadline: string = ''
    public assigneeId: string = ""
    public workflowItems: Array<WorkflowItem> = []
}