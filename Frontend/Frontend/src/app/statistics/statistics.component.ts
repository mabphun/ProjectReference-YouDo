import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BaseChartDirective } from 'ng2-charts';

import { PiechartComponent } from '../piechart/piechart.component';
import { MatButtonModule } from '@angular/material/button';
import { LinechartComponent } from '../linechart/linechart.component';
import { TaskListService } from '../_services/tasklist.service';
import { TaskList } from '../_models/tasklistmodel';
import { TaskItem } from '../_models/taskitemmodel';
import { Router, RouterModule } from '@angular/router';
import { Title } from '@angular/platform-browser';


@Component({
  selector: 'app-statistics',
  standalone: true,
  imports: [
    CommonModule,
    BaseChartDirective,
    PiechartComponent,
    LinechartComponent,
    MatButtonModule,
    RouterModule
  ],
  templateUrl: './statistics.component.html',
  styleUrl: './statistics.component.scss'
})
export class StatisticsComponent implements OnInit {
  _taskListService: TaskListService
  lists: Array<TaskList>
  selectedTasks: Array<TaskItem>
  router = inject(Router)

  constructor(
    taskListService: TaskListService,
    private titleService: Title
  ){
    titleService.setTitle('Statistics | YouDo')
    this._taskListService = taskListService
    this.lists = []
    this.selectedTasks = []
  }
  
  ngOnInit(): void {
    this._taskListService.getTaskListDtos()
    .subscribe({
      next: (r) => {
        this.lists = this._taskListService.mapTaskListArrayFromDtos(r)
      },
      error: (e) => console.log(e),
      complete: () => {console.log(this.lists)}
    })
  }

  filter(orderNumber: number){
    this.selectedTasks.splice(0, this.selectedTasks.length)
    if (this.lists.length > 0){
      this.lists.forEach(list=> {
        if (list.tasks.length > 0){
          list.tasks.forEach(task => {
            if (task.getCurrentWorkflowItem().order === orderNumber){
              this.selectedTasks.push(task)
            }
          })
        }
      })
    }
  }

  getNumberOfTodoTasks(){
    let number = 0
    if (this.lists.length > 0){
      this.lists.forEach(list=> {
        if (list.tasks.length > 0){
          list.tasks.forEach(task => {
            if (task.getCurrentWorkflowItem().order === 0){
              number++
            }
          })
        }
      })
    }
    return number
  }

  getNumberOfDoneTasks(){
    let number = 0
    if (this.lists.length > 0){
      this.lists.forEach(list=> {
        if (list.tasks.length > 0){
          list.tasks.forEach(task => {
            if (task.getCurrentWorkflowItem().order === 100){
              number++
            }
          })
        }
      })
    }
    return number
  }
  

}
