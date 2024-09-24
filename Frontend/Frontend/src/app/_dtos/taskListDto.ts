import { AppUserDto } from "./appUserDto"
import { TaskItemDto } from "./taskItemDto"

export class TaskListDto{
    public id: string = ''
    public name: string = ''
    public description: string = ''
    //public creatorId: string = ''
    public creator: AppUserDto = new AppUserDto()
    public tasks: Array<TaskItemDto> = []
    public assignedMembers: Array<AppUserDto> = []
}

/*
"id": "string",
  "name": "string",
  "description": "string",
  "isDeleted": true,
  "deletedOn": "2024-03-14T11:52:18.324Z",
  "creatorId": "string",
  "creator": {
    "id": "string",
    "userName": "string",
    "image": "string",
    "firstName": "string",
    "lastName": "string"
  },
*/