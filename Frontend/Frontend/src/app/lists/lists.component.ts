import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient} from '@angular/common/http';

import { ApiService } from '../_services/api.service';
import { TaskList } from '../_models/tasklistmodel';
import { MatButtonModule } from '@angular/material/button';
import { RouterModule } from '@angular/router';
import { TaskListService } from '../_services/tasklist.service';
import { ListCreatorDialogData } from '../dialogs/_dialog-helpers/listCreatorDialogData';
import { ListCreatorComponent } from '../dialogs/list-creator/list-creator.component';
import { MatDialog } from '@angular/material/dialog';
import { CreateTaskListDto } from '../_dtos/createTaskListDto';
import { MatIconModule } from '@angular/material/icon';
import { CheckDecisionDialogData } from '../dialogs/_dialog-helpers/checkDecisionDialogData';
import { DecisionCheckComponent } from '../dialogs/decision-check/decision-check.component';
import { Title } from '@angular/platform-browser';
import { ErrorHandlerDialogData } from '../dialogs/_dialog-helpers/errorHandlerDialogData';
import { ErrorHandlerComponent } from '../dialogs/error-handler/error-handler.component';

@Component({
  selector: 'app-lists',
  standalone: true,
  imports: [CommonModule, RouterModule, MatButtonModule, MatIconModule],
  templateUrl: './lists.component.html',
  styleUrl: './lists.component.scss'
})
export class ListsComponent implements OnInit {
  apiService: ApiService
  http: HttpClient

  _taskListService: TaskListService

  lists: Array<TaskList>

  constructor(
    http: HttpClient, 
    apiService: ApiService,
    taskListService: TaskListService,
    public dialog: MatDialog,
    private titleService: Title
    ){
    titleService.setTitle('Lists | YouDo')
    this.http = http
    this.apiService = apiService
    this._taskListService = taskListService
    
    this.lists = []
  }

  ngOnInit() {
    this._taskListService.getTaskListDtos()
    .subscribe({
      next: (r) => {
        this.lists = this._taskListService.mapTaskListArrayFromDtos(r)
      },
      error: (e) => this.handleError(e),
      complete: () => {console.log(this.lists)}
    })
  }

  displayText(text: string): string {
    return text.replace(/\n/g, '<br>');
  }

  openDeleteDialog(list: TaskList): void{
    let dialogData = new CheckDecisionDialogData
    dialogData.title = 'Are you sure?'
    dialogData.description = 'List "' + list.name + '" will be deleted.'
    const dialogRef = this.dialog.open(DecisionCheckComponent, {
      data: dialogData,
    });

    dialogRef.afterClosed().subscribe(result => {
      dialogData = result
      console.log('The dialog was closed');
      console.log(dialogData);
      
      if (dialogData?.result === true){
        this.deleteList(list)
      }
    });
  }

  deleteList(list: TaskList) : void{
    this._taskListService.deleteTaskList(list.id)
    .subscribe({
      next: (v) => {
        let index = this.lists.indexOf(list)
        this.lists.splice(index, 1)
      },
      error: (e) => {
        this.handleError(e);
      },
      complete: () => console.log('Delete completed')
    })
  }

  openCreatorDialog() : void{
    let dialogData = new ListCreatorDialogData()
    const dialogRef = this.dialog.open(ListCreatorComponent, {
      data: dialogData,
    });

    dialogRef.afterClosed().subscribe(result => {
      dialogData = result
      console.log('The dialog was closed');
      console.log(result);

      
      //Clicked Positive
      if (dialogData?.result === true){
        dialogData.list.creatorId = this.apiService.getUserId()

        this._taskListService.createTaskList(dialogData.list)
        .subscribe({
          next: (r) => {
            console.log(r);

            let list = this._taskListService.mapTaskListFromDto(r)
            this.lists.push(list)

          },
          error: (e) =>{
            this.handleError(e);
          },
          complete: () => {
            console.log('TaskList creation completed');
          }
        })
      }
    });
  }


  handleError(error: any){
    if(error.status === 401){
      let dialogData = new ErrorHandlerDialogData
      dialogData.title = 'Access violation'
      dialogData.description = 'You are unauthorized to access this content.'
      this.openErrorDialog(dialogData)
    }
    else if(error.status === 500){
      let dialogData = new ErrorHandlerDialogData
      dialogData.title = 'Internal Server Error'
      dialogData.description = 'Oops! Something unexpected happened.'
      this.openErrorDialog(dialogData)
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
    });
  }
}
