import { Component, Inject, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MAT_DIALOG_DATA, MatDialogActions, MatDialogClose, MatDialogContent, MatDialogRef, MatDialogTitle } from '@angular/material/dialog';
import { TaskCreatorDialogData } from '../_dialog-helpers/taskCreatorDialogData';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatMomentDateModule, provideMomentDateAdapter } from '@angular/material-moment-adapter';
import { MatSelectModule } from '@angular/material/select';
import moment from 'moment';
import { MOMENT_FORMATS } from '../../_helpers/moment-format';
import { MatIconModule } from '@angular/material/icon';
import { DateConverter } from '../../_services/date.converter';
import { TaskItemService } from '../../_services/taskitem.service';
import { TaskItemDto } from '../../_dtos/taskItemDto';
import { MatTooltipModule } from '@angular/material/tooltip';
import { TaskItem } from '../../_models/taskitemmodel';

@Component({
  selector: 'app-task-creator',
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
    ReactiveFormsModule,
    MatDatepickerModule,
    MatMomentDateModule,
    MatSelectModule,
    MatIconModule,
    MatTooltipModule,
  ],
  providers: [provideMomentDateAdapter(MOMENT_FORMATS)],
  templateUrl: './task-creator.component.html',
  styleUrl: './task-creator.component.scss'
})
export class TaskCreatorComponent implements OnInit {
  dateConverter = inject(DateConverter)
  _taskItemService = inject(TaskItemService)
  minDate: Date
  maxDate: Date

  tasks: Array<TaskItem>

  estimation: number

  showHelper: boolean

  date = new FormControl(moment().local().format('YYYY-MM-DD hh:mm:ss'));

  constructor(
    public dialogRef: MatDialogRef<TaskCreatorComponent>,
    @Inject(MAT_DIALOG_DATA) public data: TaskCreatorDialogData,
  ) {
    const currentYear = new Date().getFullYear();
    const currentDate = new Date()
    //this.minDate = new Date(currentYear - 20, 0, 1);
    this.minDate = currentDate
    this.maxDate = new Date(currentYear + 10, 11, 31);

    this.estimation = -1

    this.showHelper = false
    this.tasks = []
  }

  ngOnInit(): void {
    this._taskItemService.getCreatedTaskItems()
    .subscribe({
      next: (r) => {
        r.forEach(element => {
          let task = this._taskItemService.mapTaskItemFromDto(element)
          this.tasks.push(task)
        });
      },
      error: (e) => {},
      complete: () => {
        console.log('Fetch completed');
        console.log(this.tasks)

        this.estimationHelper()
      }
    })
  }

  isAnyError(): boolean{
    if(this.data.task.title === '') return true
    if(this.data.task.estimated < 0) return true

    return false
  }

  estimationHelper(){
    if (this.tasks.length === 0){
      this.estimation = -1     
      return
    }

    let sumEstim = 0
    let sumWorkTime = 0
    this.tasks.forEach(task => {
      if (task.getCurrentWorkflowItem().order === 100){
        sumEstim += task.estimated
        let taskWorkTime = 0
        task.userWorkLogs.forEach(uwl => { taskWorkTime += uwl.workTimeInMins / 60})
        let rounded = Math.round(taskWorkTime * 10) / 10
        sumWorkTime += rounded
      }
    });

    console.log(sumEstim + ' ' + sumWorkTime);
    
    if (sumEstim === 0 || sumWorkTime === 0){
      this.estimation = -1
      return
    }

    let avgEstim = sumEstim / this.tasks.length || 0
    let avgWorkTime = sumWorkTime / this.tasks.length || 0
    if (avgEstim * 1.1 >= avgWorkTime && avgEstim * 0.9 <= avgWorkTime){
      this.estimation = 0
    }
    else if (avgEstim * 0.9 > avgWorkTime){
      this.estimation = 2
    }
    else if(avgEstim * 1.1 < avgWorkTime){
      this.estimation = 1
    }

    return
  }

  onYesClick(): void{
    this.data.task.deadline = this.date.value != null ? this.date.value : ''
    this.data.result = true
    this.dialogRef.close(this.data);
  }

  onNoClick(): void {
    this.data.result = false
    this.dialogRef.close(this.data);
  }
}
