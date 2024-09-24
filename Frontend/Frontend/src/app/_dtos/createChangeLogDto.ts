import { WorkflowItem } from "../_models/workflowitemmodel"

export class CreateChangeLogDto{
    taskItemId: string = ''
    changerId: string = ''

    oldTitle: string = ''
    oldDetails: string = ''
    oldPriority: string = ''
    oldAssigneeId: string = ''
    oldDeadline: string = ''
    oldWorkflowItem: WorkflowItem = new WorkflowItem

    newTitle: string = ''
    newDetails: string = ''
    newPriority: string = ''
    newAssigneeId: string = ''
    newDeadline: string = ''
    newWorkflowItem: WorkflowItem = new WorkflowItem
}