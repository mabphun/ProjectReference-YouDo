import { AppUserDto } from "../../_dtos/appUserDto"
import { TaskList } from "../../_models/tasklistmodel"

export class UserManagerDialogData{
    list: TaskList = new TaskList
    members: Array<AppUserDto> = []
    result: boolean = false
}