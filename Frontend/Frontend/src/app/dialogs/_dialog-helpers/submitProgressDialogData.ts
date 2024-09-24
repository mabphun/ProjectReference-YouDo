import { TaskItem } from "../../_models/taskitemmodel"

export class SubmitProgressDialogData{
    task: TaskItem = new TaskItem
    estimatedHours: number = 0

    time: number = 0
    result: boolean = false
}