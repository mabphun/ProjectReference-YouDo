import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { TaskList } from '../_models/tasklistmodel';
import { APP_URLS } from '../app.urls';
import { MatTableModule, MatTableDataSource} from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { TaskItem } from '../_models/taskitemmodel';
import { MatButtonModule } from '@angular/material/button';
import { WorkflowItem } from '../_models/workflowitemmodel';
import { CreateTaskItemDto } from '../_dtos/createTaskItemDto';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { ApiService } from '../_services/api.service';
import { MatMomentDateModule, provideMomentDateAdapter } from '@angular/material-moment-adapter';
import { MatSelectModule } from '@angular/material/select';
import {MatChipsModule} from '@angular/material/chips';

import * as _moment from 'moment';
// tslint:disable-next-line:no-duplicate-imports
import {default as _rollupMoment} from 'moment';
import { TaskItemPriority } from '../_models/tasklistpriority';
import { TaskListDto } from '../_dtos/taskListDto';
import { AppUserDto } from '../_dtos/appUserDto';
import { PriorityConverter } from '../_services/priority.converter';
import { Observable } from 'rxjs';
import { TaskListService } from '../_services/tasklist.service';
import { TaskCreatorDialogData } from '../dialogs/_dialog-helpers/taskCreatorDialogData';
import { MatDialog } from '@angular/material/dialog';
import { TaskCreatorComponent } from '../dialogs/task-creator/task-creator.component';
import { MOMENT_FORMATS } from '../_helpers/moment-format';
import { TaskItemService } from '../_services/taskitem.service';
import { CheckDecisionDialogData } from '../dialogs/_dialog-helpers/checkDecisionDialogData';
import { DecisionCheckComponent } from '../dialogs/decision-check/decision-check.component';
import { UserManagerComponent } from '../dialogs/user-manager/user-manager.component';
import { UserManagerDialogData } from '../dialogs/_dialog-helpers/userManagerDialogData';
import { Title } from '@angular/platform-browser';
import { DateConverter } from '../_services/date.converter';
import { ErrorHandlerDialogData } from '../dialogs/_dialog-helpers/errorHandlerDialogData';
import { ErrorHandlerComponent } from '../dialogs/error-handler/error-handler.component';

const moment = _rollupMoment || _moment;

/*
export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H'},
  {position: 2, name: 'Helium', weight: 4.0026, symbol: 'He'},
  {position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li'},
  {position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be'},
  {position: 5, name: 'Boron', weight: 10.811, symbol: 'B'},
  {position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C'},
  {position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N'},
  {position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O'},
  {position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F'},
  {position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne'},
];
*/

export interface TaskItemDataSource{
  task: TaskItem
  assignee: AppUserDto
  priority: string
  workflow: string
  updatedAt: string
}


@Component({
  selector: 'app-list',
  standalone: true,
  imports: [
    CommonModule, 
    MatTableModule, 
    MatInputModule, 
    MatFormFieldModule,
    MatButtonModule,
    FormsModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatMomentDateModule,
    MatSelectModule,
    RouterModule,
    MatChipsModule
  ],
  //providers: [{provide: MAT_DATE_LOCALE, useValue: 'hu-HU'}],
  //providers: [provideNativeDateAdapter(DATE_FORMATS)],
  providers: [provideMomentDateAdapter(MOMENT_FORMATS)],
  templateUrl: './list.component.html',
  styleUrl: './list.component.scss'
})
export class ListComponent implements OnInit {
  http: HttpClient
  route: ActivatedRoute
  router: Router
  list: TaskList
  editedList: TaskList
  isInEditMode: boolean = false
  api: ApiService
  _taskListService: TaskListService
  _taskItemService: TaskItemService
  dateConverter: DateConverter

  dataSource: TaskItemDataSource[] = []
  filteredDataSource: TaskItemDataSource[] = []

  minDate: Date
  maxDate: Date
  date = new FormControl(moment().format('YYYY-MM-DD hh:mm:ss'));
  
  enableMatView: boolean = true

  prioConverter: PriorityConverter

  //displayedColumns: string[] = ['title', 'priority', 'symbol', 'position'];
  displayedColumns: string[] = ['task', 'priority', 'assignee', 'workflow'];

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

  constructor(
    http: HttpClient, 
    route: ActivatedRoute, 
    router: Router, 
    api: ApiService,
    prioConverter: PriorityConverter,
    taskListService: TaskListService,
    taskItemService: TaskItemService,
    dateConverter: DateConverter,
    public dialog: MatDialog,
    private titleService: Title
    ){
    this.http = http
    this.route = route
    this.router = router
    this.prioConverter = prioConverter

    this.api = api

    const currentYear = new Date().getFullYear();
    const currentDate = new Date()
    this.minDate = currentDate
    this.maxDate = new Date(currentYear + 10, 11, 31);

    this.list = new TaskList
    this.editedList = new TaskList

    this._taskListService = taskListService
    this._taskItemService = taskItemService
    this.dateConverter = dateConverter
  }

  ngOnInit(): void {
    this.loadList()
  }

  loadList(){
    this.route.params.subscribe(param=>{
      let id = param['id']

      this._taskListService.getTaskListDto(id)
      .subscribe({
        next: (r) => {
          this.list = this._taskListService.mapTaskListFromDto(r)
          this.titleService.setTitle(this.list.name + ' | YouDo')
        },
        error: (e) => {
          this.handleError(e)
        },
        complete: () =>{
          //this.dataSource = new MatTableDataSource(this.tasks);
          console.log(this.list);
          let data: TaskItemDataSource[] = []
          for (let i = 0; i < this.list.tasks.length; i++) {
            const element = this.list.tasks[i];
            let currentWorkflow = element.workflowItems.find((items) => items.isActive)
            data.push({
              task: element,
              assignee: element.assignee, 
              priority: this.prioConverter.ConvertPriorityToString(element.priority),
              workflow: currentWorkflow !== undefined ? currentWorkflow.name : "Undefined",
              updatedAt: element.updatedAt
            })
          }
          this.dataSource = data
          this.dataSource.sort(function (left, right) {
            return moment.utc(right.updatedAt).diff(moment.utc(left.updatedAt))
          })
          this.dataSource = [...this.dataSource]

          this.applyFilter('')
        }
      })
    })
  }

//=================================================
//=================================================
//=================================================
// EDIT LIST
//=================================================
//=================================================
//=================================================

  editList(): void{
    this._taskListService.mapTaskListFromTaskList(this.editedList, this.list)
    this.isInEditMode = true
  }

  openSaveDialog(): void{
    let dialogData = new CheckDecisionDialogData
    dialogData.title = 'Are you sure?'
    dialogData.description = 'Changes will be saved.'
    const dialogRef = this.dialog.open(DecisionCheckComponent, {
      data: dialogData,
    });

    dialogRef.afterClosed().subscribe(result => {
      dialogData = result
      console.log('The dialog was closed');
      console.log(dialogData);
      
      if (dialogData?.result === true){
        this.saveList()
      }
    });
  }

  saveList(): void{
    this._taskListService.mapTaskListFromTaskList(this.list, this.editedList)
    this.isInEditMode = false
    let updateDto = this._taskListService.mapUpdateTaskListDto(this.list)
    console.log(updateDto);
    
    this._taskListService.updateTaskList(updateDto)
    .subscribe({
      next: (r) => {
        this.list = this._taskListService.mapTaskListFromDto(r)
      },
      error: (e) => this.handleError(e),
      complete: () => console.log('Update completed')    
    })
    
  }

  cancelEditing(): void{
    this.isInEditMode = false
  }

  displayText(): string {
    return this.list.description.replace(/\n/g, '<br>');
  }


//=================================================
//=================================================
//=================================================
// CREATE TASK
//=================================================
//=================================================
//=================================================

  openCreatorDialog() : void{
    let dialogData = new TaskCreatorDialogData()
    const dialogRef = this.dialog.open(TaskCreatorComponent, {
      data: dialogData,
    });

    dialogRef.afterClosed().subscribe(result => {
      dialogData = result
      console.log('The dialog was closed');
      console.log(dialogData);
      
      //Action
      if (dialogData?.result === true){
        this.createTaskItem(dialogData.task)
      }
    });
  }

  createTaskItem(createTaskItemDto: CreateTaskItemDto) : void{
    this.route.params.subscribe(param=>{
      let taskListId = param['id']
      createTaskItemDto.taskListId = taskListId
      createTaskItemDto.creatorId = this.api.getUserId()

      console.log(createTaskItemDto.deadline);
      if (!moment.isMoment(createTaskItemDto.deadline)){
        let temp = moment(createTaskItemDto.deadline).local().format('YYYY.MM.DD')
        let utc = moment(temp, 'YYYY.MM.DD').utc().toJSON()
        createTaskItemDto.deadline = utc
        console.log(createTaskItemDto.deadline);
        
        
        //createTaskItemDto.deadline = this.dateConverter.StringToUtcMomentJson(createTaskItemDto.deadline)
      }
      
      //createTaskItemDto.deadline = moment(createTaskItemDto.deadline).utc().format('YYYY-MM-DD')
      
      console.log(createTaskItemDto);
      
      //console.log(moment(createTaskItemDto.deadline).toJSON());
      
      this._taskItemService.createTaskItem(createTaskItemDto)
      .subscribe({
        next: (r) => {
          let task = this._taskItemService.mapTaskItemFromDto(r)
          let currentWorkflow = task.workflowItems.find((items) => items.isActive)
          this.dataSource.push({
            task: task,
            assignee: task.assignee, 
            priority: this.prioConverter.ConvertPriorityToString(task.priority),
            workflow: currentWorkflow !== undefined ? currentWorkflow.name : "Undefined",
            updatedAt: task.updatedAt
          })
          this.dataSource.sort(function (left, right) {
            return moment.utc(right.updatedAt).diff(moment.utc(left.updatedAt))
          })
          this.dataSource = [...this.dataSource]
          this.applyFilter('')
        },
        error: (e) =>{
          this.handleError(e)
        },
        complete: () => {
          console.log('TaskItem creation completed');
        }
      })
    })
  }

//=================================================
//=================================================
//=================================================
// ERROR HANDLER
//=================================================
//=================================================
//=================================================

  handleError(error: any){
    if(error.status === 401){
      let dialogData = new ErrorHandlerDialogData
      dialogData.title = 'Error!'
      dialogData.description = error.error
      this.openErrorDialog(dialogData)
    }
    else if(error.status === 500){
      let dialogData = new ErrorHandlerDialogData
      dialogData.title = 'Internal Server Error'
      dialogData.description = 'Oops! Something unexpected happened.'
      this.openErrorDialog(dialogData)
    }
    else if(error.status === 400){
      let dialogData = new ErrorHandlerDialogData
      dialogData.title = 'Bad request'
      dialogData.description = error.error
      this.openErrorDialog(dialogData)
    }
    else{
      console.log(error);
      console.log(error.error.message);
      
      
    }
  }

  openErrorDialog(dialogData: ErrorHandlerDialogData): void{
    const dialogRef = this.dialog.open(ErrorHandlerComponent, {
      data: dialogData,
    });

    dialogRef.afterClosed().subscribe(result => {
      dialogData = result
      console.log('The dialog was closed');
      console.log(dialogData);
      this.loadList()
    });
  }

//=================================================
//=================================================
//=================================================
// USER MANAGER
//=================================================
//=================================================
//=================================================

  openUserManagerDialog(): void{
    let dialogData = new UserManagerDialogData()
    dialogData.list = this.list
    const dialogRef = this.dialog.open(UserManagerComponent, {
      data: dialogData,
    });

    dialogRef.afterClosed().subscribe(result => {
      dialogData = result
      console.log('The dialog was closed');
      console.log(dialogData);
      
      //Action
      if (dialogData?.result === true){
        this.list.assignedMembers = []
        dialogData.members.forEach(member => {
          this.list.assignedMembers.push(member)
        });

        console.log(this.list.assignedMembers);
        
        //update
        let updateDto = this._taskListService.mapUpdateTaskListDto(this.list)
        console.log(updateDto);
        
        this._taskListService.updateTaskList(updateDto)
        .subscribe({
          next: (r) => {
            this.list = this._taskListService.mapTaskListFromDto(r)
          },
          error: (e) => this.handleError(e),
          complete: () => console.log('Update completed')    
        })
      }
    });
  }
}
