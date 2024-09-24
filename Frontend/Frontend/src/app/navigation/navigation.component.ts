import { Component, OnDestroy, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
// import {MatButtonToggleModule} from '@angular/material/button-toggle'
import {MatToolbarModule} from '@angular/material/toolbar';
import { Router, RouterModule } from '@angular/router';
import { ApiService } from '../_services/api.service';
import { SignalRService } from '../_services/signalr.service';
import { NotificationDto } from '../_dtos/notificationDto';
import { MatMenuModule } from '@angular/material/menu';
import { DateConverter } from '../_services/date.converter';
import { MatTooltipModule } from '@angular/material/tooltip';

@Component({
  selector: 'app-navigation',
  standalone: true,
  imports: [
    CommonModule, 
    MatIconModule, 
    MatButtonModule, 
    MatToolbarModule, 
    RouterModule,
    MatMenuModule,
    MatTooltipModule
  ],
  templateUrl: './navigation.component.html',
  styleUrl: './navigation.component.scss'
})
export class NavigationComponent implements OnInit, OnDestroy{
  apiService: ApiService

  notifications: Array<NotificationDto>
  isNewNotification: boolean
  showAnimation: boolean
  
  constructor(
    apiService:ApiService,
    private _signalRService: SignalRService,
    public _dateConverter: DateConverter,
    private router: Router
  ){
    this.apiService = apiService
    this.notifications = []
    this.isNewNotification = false
    this.showAnimation = false
  }

  ngOnInit(): void {
    setTimeout(() => {
      console.log('Navigation started');
      this.taskListUpdateListener()

      this.taskItemUpdateListener()
      this.taskItemCreateListener()
    }, 2000)
  }

  ngOnDestroy(): void {
    this._signalRService.hubCon.off('TaskListUpdateResponse')
    this._signalRService.hubCon.off('TaskItemUpdateResponse')
    this._signalRService.hubCon.off('TaskItemCreatedResponse')
  }

  taskListUpdateListener(){
    this._signalRService.hubCon.on('TaskListUpdateResponse', (resp: NotificationDto) =>{
      console.log('[SignalR] TaskListUpdateDone');
      console.log(resp);
      this.notifications.push(resp)

      this.isNewNotification = true
      this.showAnimation = true
      setTimeout(() => {
        this.showAnimation = false
      }, 2000)
    })
  }

  taskItemUpdateListener(){
    this._signalRService.hubCon.on('TaskItemUpdateResponse', (resp: NotificationDto) =>{
      console.log('[SignalR] TaskItemUpdateDone');
      console.log(resp);
      this.notifications.push(resp)

      this.isNewNotification = true
      this.showAnimation = true
      setTimeout(() => {
        this.showAnimation = false
      }, 2000)
    })
  }

  taskItemCreateListener(){
    this._signalRService.hubCon.on('TaskItemCreatedResponse', (resp: NotificationDto) =>{
      console.log('[SignalR] TaskItemCreateDone');
      console.log(resp);
      this.notifications.push(resp)

      this.isNewNotification = true
      this.showAnimation = true
      setTimeout(() => {
        this.showAnimation = false
      }, 2000)
    })
  }

  clearNotifications(){
    this.notifications.splice(0, this.notifications.length)
  }

  showNotifications(){
    this.isNewNotification = false
  }

  getDate(input: string) : string {
    let resp = this._dateConverter.momentRef.utc(input).local().format('YYYY.MM.DD HH:mm')
    return resp
  }

  getUrl(notif: NotificationDto){
    let resp = '/'+ notif.itemType +'/'+ notif.itemId
    return resp
  }

  navToUrl(notif: NotificationDto){
    let url = this.getUrl(notif)
    this.router.navigate([url])
  }
}
