import { AppUserDto } from "./appUserDto"

export class UpdateTaskListDto {
    public id: string = ''
    public name: string = ''
    public description: string = ''
    public assignedMembers: Array<AppUserDto> = []
}