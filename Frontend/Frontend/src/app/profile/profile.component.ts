import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppUserService } from '../_services/appuser.service';
import { AppUserDto } from '../_dtos/appUserDto';
import { TaskListService } from '../_services/tasklist.service';
import { TaskList } from '../_models/tasklistmodel';
import { RouterModule } from '@angular/router';
import { TaskItem } from '../_models/taskitemmodel';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule
  ],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss'
})
export class ProfileComponent implements OnInit {
  _appUserService: AppUserService
  _taskListService: TaskListService
  user: AppUserDto
  lists: Array<TaskList>
  tasks: Array<TaskItem>

  constructor(
    appUserService: AppUserService,
    taskListService: TaskListService,
    private titleService: Title
  ){   
    titleService.setTitle('Profile | YouDo')
    this._appUserService = appUserService
    this._taskListService = taskListService
    this.user = new AppUserDto
    this.lists = []
    this.tasks = []
  }

  ngOnInit(): void {
    this._appUserService.getCurrentUser()
    .subscribe({
      next: (r) => {
        this.user = r
        console.log(this.user);
      },
      error: (e) => {},
      complete: () => {
        this._taskListService.getTaskListDtos()
        .subscribe({
          next: (r) => {
            this.lists = this._taskListService.mapTaskListArrayFromDtos(r)
            console.log(this.lists);
            this.lists.forEach(list => {
              if (list.tasks.length > 0){
                list.tasks.forEach(task => {
                  this.tasks.push(task)
                })
              }
            })
            console.log(this.tasks);
          },
          error: (e) => {},
          complete: () => {}
        })
      }
    })
  }

}
