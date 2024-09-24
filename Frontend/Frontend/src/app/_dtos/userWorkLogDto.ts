import { AppUserDto } from "./appUserDto"
import { TaskItemDto } from "./taskItemDto"

export class UserWorkLogDto{
    appUser: AppUserDto = new AppUserDto()
    taskItem: TaskItemDto = new TaskItemDto()
    workTimeInMins: number = 0
    logDate: string = ''
}