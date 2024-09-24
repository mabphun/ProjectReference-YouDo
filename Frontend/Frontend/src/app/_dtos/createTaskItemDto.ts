
export class CreateTaskItemDto {
    public title: string = ''
    public details: string = ''
    public priority: string = '1'
    public deadline: string = ''
    public taskListId: string = ''
    public creatorId: string = ''
    public estimated: number = 0
}
