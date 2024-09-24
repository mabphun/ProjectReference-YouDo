import { Component, Inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogTitle, MatDialogContent, MatDialogActions, MatDialogClose, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { WorkflowEditorDialogData } from '../_dialog-helpers/workflowEditorDialogData';
import { WorkflowItem } from '../../_models/workflowitemmodel';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';

@Component({
  selector: 'app-workflow-editor',
  standalone: true,
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatButtonModule,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose,
    MatCheckboxModule,
    MatIconModule,
    MatTooltipModule,
  ],
  templateUrl: './workflow-editor.component.html',
  styleUrl: './workflow-editor.component.scss'
})
export class WorkflowEditorComponent implements OnInit {
  workflows: Array<WorkflowItem>
  
  multipleActive: boolean
  noneActive: boolean
  matchingOrders: boolean
  requiredValues: boolean
  orderRange: boolean

  constructor(
    public dialogRef: MatDialogRef<WorkflowEditorComponent>,
    @Inject(MAT_DIALOG_DATA) public data: WorkflowEditorDialogData,
  ) {
    this.workflows = []
    this.multipleActive = false
    this.noneActive = false
    this.matchingOrders = false
    this.requiredValues = false
    this.orderRange = false
  }

  ngOnInit(): void {
    this.data.workflows.forEach(wf => {
      let i = wf.getCopy()
      this.workflows.push(i)
      /*
      let newWf = new WorkflowItem
      newWf.id = wf.id
      newWf.name = wf.name
      newWf.isActive = wf.isActive
      newWf.colorCode = wf.colorCode
      newWf.isDeletable = wf.isDeletable
      newWf.order = wf.order
      newWf.taskItemId = wf.taskItemId
      this.workflows.push(newWf)
      */
    })
    this.orderWorkflows()
  }

  addNewWorkflow(){
    let wf = new WorkflowItem()
    wf.order = this.getFirstOpenNumber(this.workflows)
    this.workflows.push(wf)
    this.orderWorkflows()
  }

  removeWorkflow(wf: WorkflowItem){
    let index = this.workflows.indexOf(wf)
    this.workflows.splice(index, 1)
    this.orderWorkflows()
  }

  orderWorkflows(){
    this.workflows.sort((a,b) => a.order - b.order)
  }

  getFirstOpenNumber(items: Array<WorkflowItem>) : number{
    let num = 1

    items.sort((a, b) => a.order - b.order)

    for (let i = 0; i < items.length; i++) {
      const wf = items[i];
      if (wf.order === num){
        num += 1
      }
      else if(wf.order > num){
        return num
      }
    }
    return num
  }

  isAnyError() : boolean{
    if (this.workflows.filter(x=> x.isActive).length > 1){
      this.multipleActive = true
      this.noneActive = false
      return true
    }
    if (this.workflows.filter(x=> x.isActive).length < 1){
      this.noneActive = true
      this.multipleActive = false
      return true
    }
    if (this.workflows.filter(x=> x.name === "").length > 0){
      this.requiredValues = true
      return true
    }
    if (this.workflows.find(x=> x.order < 1 && x.isDeletable) !== undefined
    || this.workflows.find(x=> x.order > 99 && x.isDeletable) !== undefined){
      this.orderRange = true
      return true
    }
    for (let i = 1; i < 100; i++) {
      if (this.workflows.filter(x=> x.order == i).length > 1){
        this.matchingOrders = true
        return true
      }
    }

    return false
  }

  onYesClick(): void{
    if (this.isAnyError()) return
    this.data.workflows = []
    this.workflows.forEach(wf => {
      this.data.workflows.push(wf)
    });
    this.data.result = true
    this.dialogRef.close(this.data);
  }

  onNoClick(): void {
    this.data.result = false
    this.dialogRef.close(this.data);
  }
}
