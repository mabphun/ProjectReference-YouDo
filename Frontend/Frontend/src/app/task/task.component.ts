import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TaskItem } from '../_models/taskitemmodel';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatButtonModule } from '@angular/material/button';
import { ApiService } from '../_services/api.service';
import { APP_URLS } from '../app.urls';
import {MatChipsModule} from '@angular/material/chips';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { TaskItemDto } from '../_dtos/taskItemDto';
import { PriorityConverter } from '../_services/priority.converter';
import * as _moment from 'moment';
// tslint:disable-next-line:no-duplicate-imports
import {default as _rollupMoment} from 'moment';
import { MatSelectModule } from '@angular/material/select';
import { WorkflowItem } from '../_models/workflowitemmodel';
import {MatMenuModule} from '@angular/material/menu';
import {MatInputModule} from '@angular/material/input';
import {FormControl, FormsModule, ReactiveFormsModule} from '@angular/forms';
import { AppUserDto } from '../_dtos/appUserDto';
import { MatDialog } from '@angular/material/dialog';
import { DecisionCheckComponent } from '../dialogs/decision-check/decision-check.component';
import { CheckDecisionDialogData } from '../dialogs/_dialog-helpers/checkDecisionDialogData';
import { ChangeLog } from '../_models/changelogmodel';
import { DateConverter } from '../_services/date.converter';
import { MatMomentDateModule, provideMomentDateAdapter } from '@angular/material-moment-adapter';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MOMENT_FORMATS } from '../_helpers/moment-format';
import { TaskItemService } from '../_services/taskitem.service';
import { ChangeLogService } from '../_services/changelog.service';
import { WorkLoggerComponent } from '../dialogs/work-logger/work-logger.component';
import { WorkLoggerDialogData } from '../dialogs/_dialog-helpers/workLoggerDialogData';
import { UserWorkLogService } from '../_services/userworklog.service';
import { CreateUserWorkLogDto } from '../_dtos/createUserWorkLogDto';
import { UserWorkLogDto } from '../_dtos/userWorkLogDto';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import { WorkflowEditorDialogData } from '../dialogs/_dialog-helpers/workflowEditorDialogData';
import { WorkflowEditorComponent } from '../dialogs/workflow-editor/workflow-editor.component';
import { CreateWorkflowItemDto } from '../_dtos/createWorkflowItemDto';
import { WorkflowItemService } from '../_services/workflowitem.service';
import { SubmitProgressDialogData } from '../dialogs/_dialog-helpers/submitProgressDialogData';
import { SubmitProgressComponent } from '../dialogs/submit-progress/submit-progress.component';
import { Title } from '@angular/platform-browser';

const moment = _rollupMoment || _moment;

@Component({
  selector: 'app-task',
  standalone: true,
  imports: [
    CommonModule, 
    MatGridListModule, 
    MatButtonModule, 
    MatChipsModule, 
    MatIconModule,
    MatFormFieldModule,
    MatSelectModule,
    MatMenuModule,
    MatInputModule,
    FormsModule,
    MatDatepickerModule,
    MatMomentDateModule,
    ReactiveFormsModule,
    MatProgressBarModule,
  ],
  providers: [provideMomentDateAdapter(MOMENT_FORMATS)],
  templateUrl: './task.component.html',
  styleUrl: './task.component.scss'
})
export class TaskComponent implements OnInit {
  route: ActivatedRoute
  router: Router
  http: HttpClient
  url: string
  api: ApiService
  _taskItemService: TaskItemService
  _changeLogService: ChangeLogService
  _userWorkLogService: UserWorkLogService
  _workflowItemService: WorkflowItemService
  
  priorityConverter: PriorityConverter
  dateConverter: DateConverter

  task: TaskItem
  editedTask: TaskItem

  moment = moment

  color: string = ''

  isInEditMode: boolean

  isTaskOverEstimated: boolean

  minDate: Date
  maxDate: Date
  date = new FormControl(moment().format('YYYY-MM-DD'));

  constructor(
    route: ActivatedRoute, 
    router: Router, 
    http: HttpClient, 
    api: ApiService,
    prioConverter: PriorityConverter,
    dateConverter: DateConverter,
    taskItemService: TaskItemService,
    changeLogService: ChangeLogService,
    userWorkLogService: UserWorkLogService,
    workflowItemService: WorkflowItemService,
    public dialog: MatDialog,
    private titleService: Title
    ){
    this.route = route
    this.router = router
    this.http = http
    this.priorityConverter = prioConverter
    this.dateConverter = dateConverter
    this.api = api
    this._taskItemService = taskItemService
    this._changeLogService = changeLogService
    this._userWorkLogService = userWorkLogService
    this._workflowItemService = workflowItemService

    this.isInEditMode = false
    this.isTaskOverEstimated = false
    
    //TODO: Feladat címe mellé egy copy gomb amivel az url másolható lesz
    // Csak a címre való hover alatt jelenik meg
    this.url = APP_URLS.root + router.url

    this.task = new TaskItem()
    this.editedTask = new TaskItem()

    const currentYear = new Date().getFullYear();
    const currentDate = new Date()
    this.minDate = currentDate
    this.maxDate = new Date(currentYear + 10, 11, 31);
  }

  ngOnInit(): void {
    this.loadTask()
  }

  loadTask(): void {
    this.route.params.subscribe(param=>{
      let id = param['id']
      // this.http.get<TaskItemDto>(APP_URLS.baseUrl + APP_URLS.taskItem + id)
      this._taskItemService.getTaskItemDto(id)
      .subscribe({
        next: (r) => {
          this.task = this._taskItemService.mapTaskItemFromDto(r)
          console.log(this.task);
          this.titleService.setTitle(this.task.title + ' | YouDo')
        },
        error: (e) => {
          console.log(e);
        },
        complete: () => {
        }
      })
    })
  }

  openSubmitProgressDialog(): void{
    let dialogData = new SubmitProgressDialogData()

    let tempTask = new TaskItem
    this._taskItemService.mapTaskItemFromTaskItem(tempTask, this.task)
    dialogData.task = tempTask

    let timeSinceLastChange = this.getDateWhereCurrentUserBecameAssignee()
    let timeDiff = 0
    if (timeSinceLastChange !== "") {
      timeDiff = this.getTimeDiff(timeSinceLastChange)
    }
    dialogData.estimatedHours = timeDiff
    const dialogRef = this.dialog.open(SubmitProgressComponent, {
      data: dialogData,
    });

    dialogRef.afterClosed().subscribe(result => {
      dialogData = result
      console.log('The dialog was closed');
      console.log(dialogData);

      if (dialogData?.result === true){
        //WorktimeLog
        //UserWorkLogDto létrehozás és elküldése a backendnek
        this.route.params.subscribe(param=>{
          let id = param['id']
          let dto = new CreateUserWorkLogDto
          dto.appUserId = this.api.getUserId()
          dto.taskItemId = id
          dto.workTimeInMins = dialogData.time
          
          this._userWorkLogService.createUserWorkLog(dto)
          .subscribe({
            next: (r) => {
              console.log(r);
              
              this.task.userWorkLogs.push(r)
              console.log(this.task.userWorkLogs)
            },
            error: (e) => {},
            complete: () => {
              //Task Update
              let changeLog = this._changeLogService.mapCreateChangeLogDto(this.task, dialogData.task)
              changeLog.oldDeadline = moment.utc(this.task.deadline).toJSON()
              changeLog.newDeadline = moment.utc(dialogData.task.deadline).toJSON()

              console.log(changeLog);
              
              //console.log(moment.utc(this.task.deadline).toJSON());
              //console.log(moment.utc(dialogData.task.deadline).toJSON());

              if (this._changeLogService.isSomethingChangedInCreateDto(changeLog) == false){
                return
              }
              
              this._taskItemService.mapTaskItemFromTaskItem(this.task, dialogData.task)

              let updateDto = this._taskItemService.createUpdateTaskItemDto(this.task)

              this._taskItemService.updateTaskItem(updateDto)
              .subscribe({
                next: (r) => {
                  this.task = this._taskItemService.mapTaskItemFromDto(r)
                  console.log(this.task);                  
                },
                error: (e) => {
                  console.log(e);
                },
                complete: () => {
                  this._changeLogService.createChangeLog(changeLog)
                  .subscribe({
                    next: (r) => {
                      console.log('Changelog added');

                      let newChangeLog = r
                      
                      this.task.changeLogs.push(newChangeLog)
                      this.task.changeLogs.sort(function (left, right) {
                        return moment.utc(right.changeDate).diff(moment.utc(left.changeDate))
                      })
                    }
                  })
                }
              })
            }
          })
        })
      }
    })
  }

  openWorkflowEditorDialog(): void{
    let dialogData = new WorkflowEditorDialogData()
    dialogData.workflows = this.task.workflowItems
    const dialogRef = this.dialog.open(WorkflowEditorComponent, {
      data: dialogData,
    });

    dialogRef.afterClosed().subscribe(result => {
      dialogData = result
      console.log('The dialog was closed');
      console.log(dialogData);

      if (dialogData?.result === true){
        this.route.params.subscribe(param=>{
          let taskItemId = param['id'] 

          let forDelete: Array<string> = []
          this.task.workflowItems.forEach(wf => {
            if (dialogData.workflows.find(x=> x.name === wf.name &&  x.order === wf.order) === undefined){
              forDelete.push(wf.id)
            }
          })

          let create: Array<CreateWorkflowItemDto> = []
          dialogData.workflows.filter(x => x.id === '').forEach(wf => {
            let temp = new CreateWorkflowItemDto()
            temp.name = wf.name
            temp.order = wf.order
            temp.isActive = wf.isActive
            temp.taskItemId = taskItemId
            create.push(temp)
          })

          let modify: Array<WorkflowItem> = []
          dialogData.workflows.filter(x => x.id !== '').forEach(wf => {
            let temp = new WorkflowItem()
            temp.id = wf.id
            temp.name = wf.name
            temp.order = wf.order
            temp.isActive = wf.isActive
            temp.taskItemId = wf.taskItemId
            temp.colorCode = wf.colorCode + "asd"
            temp.isDeletable = wf.isDeletable
            modify.push(temp)
          })

          // Create request
          this._workflowItemService.createWorkflowItems(create)
          .subscribe({
            next: (r) => console.log(r),
            error: (e) => console.log(e),
            complete: () => {
              console.log('WF Create Done')
              // update request
              this._workflowItemService.updateWorkflowItems(modify)
              .subscribe({
                next: (r) => console.log(r),
                error: (e) => console.log(e),
                complete: () => {
                  console.log('WF Update Done')
                  
                  // Delete request
                  forDelete.forEach(id => {
                    this._workflowItemService.deleteWorkflowItem(id)
                    .subscribe({
                      next: (r) => {},
                      error: (e) => console.log(e),
                      complete: () => {
                        console.log('WF Delete Done')
                        //this.loadTask()
                      }
                    })
                  })
                  this.loadTask()
                }
              })
            }
          })

          
        })
      }
    });
  }


  getDateWhereCurrentUserBecameAssignee() : string {
    let userId = this.api.getUserId()
    let changeLog = this.task.changeLogs.find(x=> x.newAssigneeId == userId)
    if (changeLog === undefined) return ""
    return changeLog.changeDate
  }

  getTimeDiff(latestChange: string): number{
    let time = moment()
    let latestTime = moment.utc(latestChange)
    //console.log(time.toJSON())
    //console.log(latestTime.toJSON());
    let timeDiff = time.diff(latestTime, 'hour', true)
    //console.log(timeDiff + ' óra az eltelt idő');

    return timeDiff
  }

  getEstimatedValue() : number {
    let sum = this.sumWorkLogs(this.task.userWorkLogs)
    let estim = this.task.estimated
    if (estim > sum){
      this.isTaskOverEstimated = false
      return 100
    }
    else{
      let total = estim / sum * 100
      this.isTaskOverEstimated = true
      return total
    }
  }

  getLoggedWorkValue() {
    let sum = this.sumWorkLogs(this.task.userWorkLogs)
    let estim = this.task.estimated
    if (estim < sum){
      this.isTaskOverEstimated = true
      return 100
    }
    else{
      let total = sum / estim * 100
      this.isTaskOverEstimated = false
      return total
    }
  }

  sumWorkLogs(uwls: Array<UserWorkLogDto>) : number{
    let sum = 0
    uwls.forEach(x=> { sum += x.workTimeInMins })
    let total = sum/60
    let rounded = Math.round(total * 10) / 10
    return rounded
  }

  showWorkLogSum(rounded: number) : string{
    return rounded.toString()
  }

  openWorkLoggerDialog(): void{
    let dialogData = new WorkLoggerDialogData()
    let timeSinceLastChange = this.getDateWhereCurrentUserBecameAssignee()
    let timeDiff = 0
    if (timeSinceLastChange !== "") {
      timeDiff = this.getTimeDiff(timeSinceLastChange)
    }
    
    dialogData.estimatedHours = timeDiff
    const dialogRef = this.dialog.open(WorkLoggerComponent, {
      data: dialogData,
    });

    dialogRef.afterClosed().subscribe(result => {
      dialogData = result
      console.log('The dialog was closed');
      console.log(dialogData);

      if (dialogData?.result === true){
        console.log(dialogData.time);
        //UserWorkLogDto létrehozás és elküldése a backendnek
        this.route.params.subscribe(param=>{
          let id = param['id']
          let dto = new CreateUserWorkLogDto
          dto.appUserId = this.api.getUserId()
          dto.taskItemId = id
          dto.workTimeInMins = dialogData.time

          if (dto.workTimeInMins === 0){
            return
          }
          console.log(dto);
          
          this._userWorkLogService.createUserWorkLog(dto)
          .subscribe({
            next: (r) => {
              this.task.userWorkLogs.push(r)
              //console.log(this.task.userWorkLogs)
            },
            error: (e) => {},
            complete: () => {}
          })
        })
      }
    });
  }

  openDeleteDialog(): void{
    let dialogData = new CheckDecisionDialogData()
    dialogData.title = 'Are you sure?'
    dialogData.description = 'This task will be deleted.'
    const dialogRef = this.dialog.open(DecisionCheckComponent, {
      data: dialogData,
    });

    dialogRef.afterClosed().subscribe(result => {
      dialogData = result
      console.log('The dialog was closed');
      console.log(dialogData);

      if (dialogData?.result === true){
        console.log(this.task.id);
        
        this._taskItemService.deleteTaskItem(this.task.id)
        .subscribe({
          next: (r) => {
            console.log(r);
          },
          error: (e) =>{
            console.log(e);
          },
          complete: () => {
            console.log('TaskItem deletion completed');
            this.router.navigate(['/list/' + this.task.taskListId], {queryParams: {id: this.task.taskListId}})
          }
        })
      }
    });
  }

  openDialog(): void {
    let dialogData = new CheckDecisionDialogData()
    dialogData.title = 'Are you sure?'
    dialogData.description = 'Changes will be saved.'
    const dialogRef = this.dialog.open(DecisionCheckComponent, {
      data: dialogData,
    });

    dialogRef.afterClosed().subscribe(result => {
      dialogData = result
      console.log('The dialog was closed');
      console.log(dialogData);
      //this.dialogData.result = result;
      if (dialogData?.result === true){
        this.saveTask()
      }
    });
  }

  cancelEditing(): void{
    this.isInEditMode = false
  }

  editTask() : void{
    this._taskItemService.mapTaskItemFromTaskItem(this.editedTask, this.task)
    this.date = new FormControl(moment.utc(this.editedTask.deadline).local().format('YYYY-MM-DD'));
    this.isInEditMode = true
  }

  saveTask() : void{
    this.editedTask.deadline = this.date.value != null ? this.date.value : ''
    
    

    let changeLog = this._changeLogService.mapCreateChangeLogDto(this.task, this.editedTask)
    console.log(changeLog);
    

    if (this._changeLogService.isSomethingChangedInCreateDto(changeLog) == false){
      this.isInEditMode = false
      return
    }

    this._taskItemService.mapTaskItemFromTaskItem(this.task, this.editedTask)
    this.isInEditMode = false

    let updateDto = this._taskItemService.createUpdateTaskItemDto(this.task)    

    this._taskItemService.updateTaskItem(updateDto)
    .subscribe({
      next: (r) => {
        //this.mapTaskItemFromDto(this.task, r)
        this.task = this._taskItemService.mapTaskItemFromDto(r)
        console.log(this.task);
        // Changelog elküldése a backendnek
        
      },
      error: (e) => {
        console.log(e);
      },
      complete: () => {
       this._changeLogService.createChangeLog(changeLog)
        .subscribe({
          next: (r) => {
            console.log('Changelog added');

            let newChangeLog = r
            
            this.task.changeLogs.push(newChangeLog)
            this.task.changeLogs.sort(function (left, right) {
              return moment.utc(right.changeDate).diff(moment.utc(left.changeDate))
            })
          }
        })
      }
    })
  }

  setEditedTaskAssignee(user: AppUserDto) : void {
    this.editedTask.assignee = user
  }

  setEditedTaskWorkflow(workflowItem: WorkflowItem) : void {
    if (workflowItem.isActive == false){
      this.editedTask.workflowItems.forEach(x=> {
        if (x.id == workflowItem.id){
          x.isActive = true         
        }
        else{
          x.isActive = false
        }
      })
    }    
  }

  displayText(): string {
    return this.task.details.replace(/\n/g, '<br>');
  }
}
