import { AppUserDto } from "./appUserDto"

export class NotificationDto{
    initiatorUser: AppUserDto = new AppUserDto
    itemId: string = ''
    itemName: string = ''
    itemType: string = ''
    time: string = ''
    action: string = ''
}