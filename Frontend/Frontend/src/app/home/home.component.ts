import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { RouterModule } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { ApiService } from '../_services/api.service';
import { MatIconModule } from '@angular/material/icon';
import { TaskList } from '../_models/tasklistmodel';
import { TaskListService } from '../_services/tasklist.service';
import { TaskItem } from '../_models/taskitemmodel';
import { AppUserDto } from '../_dtos/appUserDto';
import { MatTableModule } from '@angular/material/table';
import { PriorityConverter } from '../_services/priority.converter';
import moment from 'moment';
import { MatChipsModule } from '@angular/material/chips';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

export interface TaskItemDataSource{
  task: TaskItem
  assignee: AppUserDto
  priority: string
  workflow: string
  updatedAt: string
  listName: string
}

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule, 
    MatButtonModule,
    MatIconModule,
    MatTableModule,
    MatChipsModule,
    MatFormFieldModule,
    MatInputModule,
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit{
  api = inject(ApiService)
  _priorityConverter = inject(PriorityConverter)
  _taskListService: TaskListService
  lists: Array<TaskList>
  dataSource: TaskItemDataSource[] = []
  filteredDataSource: TaskItemDataSource[] = []
  displayedColumns: string[] = ['task', 'priority', 'assignee', 'workflow', 'listname'];

  constructor(
    private titleService: Title,
    taskListService: TaskListService
  ){
    titleService.setTitle('Home | YouDo')
    this._taskListService = taskListService
    this.lists = []
  }

  ngOnInit(): void {
    if (this.api.isLoggedIn()){
      this._taskListService.getTaskListDtos()
      .subscribe({
        next: (r) => {
          this.lists = this._taskListService.mapTaskListArrayFromDtos(r)
          console.log(this.lists);
        },
        error: (e) => {
          console.log(e);
        },
        complete: () =>{
          //this.dataSource = new MatTableDataSource(this.tasks);
          let data: TaskItemDataSource[] = []
          this.lists.forEach(list => {
            for (let i = 0; i < list.tasks.length; i++) {
              const element = list.tasks[i];
              data.push({
                task: element,
                assignee: element.assignee, 
                priority: this._priorityConverter.ConvertPriorityToString(element.priority),
                workflow: element.getCurrentWorkflow(),
                updatedAt: element.updatedAt,
                listName: list.name
              })
            }
          })
          this.dataSource = data
          this.dataSource.sort(function (left, right) {
            return moment.utc(right.updatedAt).diff(moment.utc(left.updatedAt))
          })
          this.dataSource = [...this.dataSource]

          this.applyFilter('')
        }
      })
    }
    else{
      // Unauthorized
    }
  }

  getFilterText(event: Event){
    const filterValue = (event.target as HTMLInputElement).value;
    this.applyFilter(filterValue)
  }

  applyFilter(filterValue: string) {
    if (filterValue !== ''){
      this.filteredDataSource = this.dataSource.filter(item => item.task.title.includes(filterValue))
    }
    else{
      this.filteredDataSource = this.dataSource
    }
  }
}
