import { Component, OnDestroy, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { NavigationComponent } from './navigation/navigation.component';
import { HttpClientModule } from '@angular/common/http';
import { ApiService } from './_services/api.service';
import { SignalRService } from './_services/signalr.service';
import { AuthService } from './_services/auth.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, NavigationComponent, HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit, OnDestroy {  

  constructor(
    private signalRService: SignalRService,
    private authService: AuthService,
    private api: ApiService
  ){
  }

  ngOnInit(): void {
    //this.setCurrentUser()
    this.signalRService.startConnection()
    
    if (this.api.isLoggedIn()){
      setTimeout(() => {
        //Reauth meghívás
        let userid = this.api.getUserId()
        this.authService.reAuthUserListener()
        this.authService.reAuthUser()
        //this.signalRService.askServerListener()
        //this.signalRService.askServer()
      }, 2000)
    }
  }

  ngOnDestroy(): void {
    this.signalRService.stopConnections()
  }

}
