export class WorkflowItem{
  public id: string = ''
  public name: string = ''
  public order: number = 0
  public isActive: boolean = false
  public taskItemId: string = ''
  public colorCode: string = ''
  public isDeletable: boolean = true

  public getCopy() : WorkflowItem{
    let wf = new WorkflowItem()
    wf.id = this.id
    wf.name = this.name
    wf.order = this.order
    wf.isActive = this.isActive
    wf.taskItemId = this.taskItemId
    wf.colorCode = this.colorCode
    wf.isDeletable = this.isDeletable
    return wf
  }
}

/*
    "id": "0ebf7ceb-563f-446c-a778-a473f9d00d9b",
    "name": "Start",
    "order": 0,
    "isActive": true,
    "taskItemId": "068a2e35-62db-4b7b-b182-71cdf91e38e5"
  }
*/