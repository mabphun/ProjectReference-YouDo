import { Component, Inject, OnDestroy, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserManagerDialogData } from '../_dialog-helpers/userManagerDialogData';
import { MAT_DIALOG_DATA, MatDialogActions, MatDialogClose, MatDialogContent, MatDialogRef, MatDialogTitle } from '@angular/material/dialog';
import { HttpClient } from '@angular/common/http';
import { APP_URLS } from '../../app.urls';
import { AppUserDto } from '../../_dtos/appUserDto';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { Observable, Subject, debounceTime, distinctUntilChanged, map, switchMap, takeUntil } from 'rxjs';
import { AppUserService } from '../../_services/appuser.service';

@Component({
  selector: 'app-user-manager',
  standalone: true,
  imports: [
    CommonModule,
    MatCheckboxModule,
    MatButtonModule,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose,
    ReactiveFormsModule,
    MatIconModule,
    FormsModule,
    MatTableModule,
    MatFormFieldModule, 
    MatInputModule,
    MatFormFieldModule
  ],
  templateUrl: './user-manager.component.html',
  styleUrl: './user-manager.component.scss'
})
export class UserManagerComponent implements OnInit{
  http = inject(HttpClient)
  _appUserService: AppUserService
  
  allUsers: Array<AppUserDto> = []
  queryUsers: Array<AppUserDto> = []
  assigned: Array<AppUserDto> = []
  queryText: string = ''

  constructor(
    public dialogRef: MatDialogRef<UserManagerComponent>,
    @Inject(MAT_DIALOG_DATA) public data: UserManagerDialogData,
    appUserService: AppUserService
  ) {
    this._appUserService = appUserService
  }

  getValue(event: Event): string {
    return (event.target as HTMLInputElement).value;
  }

  //private searchText$ = new Subject<string>();
  //users$!: Observable<Array<AppUserDto>>;

  ngOnInit(): void {
    this._appUserService.getUsers()
    .subscribe({
      next: (r) => {
        r.map(user =>{
          this.allUsers.push(user)
        })
      },
      error: (e) => console.log(e),
      complete: () => console.log('Fetch done')
    })
    
    this.data.list.assignedMembers.forEach(member => this.assigned.push(member))
    
    console.log(this.data.list.assignedMembers);
    console.log(this.assigned);
    
  }

  onYesClick(): void{
    //this.data.list.assignedMembers = []
    this.assigned.forEach(member => {
      this.data.members.push(member)
    });
    this.data.result = true
    console.log(this.data);
    
    this.dialogRef.close(this.data);
  }

  onNoClick(): void {
    this.data.result = false
    this.dialogRef.close(this.data);
  }

  search(userNameQuery: string) {
    this.queryText = userNameQuery
    this.queryUsers = []
    this.allUsers.filter(item1 => item1.userName.includes(userNameQuery) && !this.assigned.some(item2 => item2.id === item1.id))
    .forEach(x=> this.queryUsers.push(x))
    /*
    this.queryText = userNameQuery
    this.searchText$.next(userNameQuery);
    */
  }

  addUser(user: AppUserDto){
    this.assigned.push(user)
    this.search(this.queryText)
    console.log(this.data.list.assignedMembers);
    console.log(this.assigned);
    //this.searchText$.next(this.queryText)
  }

  removeUser(user:AppUserDto){
    let index = this.assigned.indexOf(user)
    this.assigned.splice(index, 1)
    this.search(this.queryText)
    console.log(this.data.list.assignedMembers);
    console.log(this.assigned);
    //this.searchText$.next(this.queryText)
  }

}
