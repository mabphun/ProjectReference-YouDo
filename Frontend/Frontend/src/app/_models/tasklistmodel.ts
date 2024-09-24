import { AppUserDto } from "../_dtos/appUserDto";
import { TaskItem } from "./taskitemmodel";

export class TaskList {
    public id: string = ""
    public name: string = ""
    public description: string = ""
    public isDeleted: boolean = false
    public deletedOn: string = ""
    public creator: AppUserDto = new AppUserDto()
    public tasks: Array<TaskItem> = []
    public assignedMembers: Array<AppUserDto> = []
}

/*
"id": "string",
    "name": "string",
    "description": "string",
    "isDeleted": true,
    "deletedOn": "2024-03-01T11:44:03.228Z",
    "creatorId": "string",
    "tasks": [
      {
        "id": "string",
        "title": "string",
        "details": "string",
        "priority": 0,
        "deadline": "2024-03-01T11:44:03.228Z",
        "createdAt": "2024-03-01T11:44:03.228Z",
        "updatedAt": "2024-03-01T11:44:03.228Z",
        "creatorId": "string",
        "assigneeId": "string",
        "taskListId": "string"
      }
    ]
*/