import { AppUserDto } from "../_dtos/appUserDto"
import { WorkflowItem } from "./workflowitemmodel"

export class ChangeLog{
    id: string = ''
    changeDate: string = ''
    taskItemId: string = ''
    changer: AppUserDto = new AppUserDto

    oldTitle: string = ''
    oldDetails: string = ''
    oldPriority: string = ''
    oldAssigneeId: string = ''
    oldAssignee: AppUserDto = new AppUserDto
    oldDeadline: string = ''
    oldWorkflowItem: WorkflowItem = new WorkflowItem

    newTitle: string = ''
    newDetails: string = ''
    newPriority: string = ''
    newAssigneeId: string = ''
    newAssignee: AppUserDto = new AppUserDto
    newDeadline: string = ''
    newWorkflowItem: WorkflowItem = new WorkflowItem
}