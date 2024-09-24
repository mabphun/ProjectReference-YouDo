import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { LoginModel } from '../_models/loginmodel';
import { HttpClient } from '@angular/common/http';
import { Router, RouterModule } from '@angular/router';
import { TokenModel } from '../_models/tokenmodel';
import { APP_URLS } from '../app.urls';
import { Title } from '@angular/platform-browser';
import {MatDividerModule} from '@angular/material/divider';
import { ErrorHandlerDialogData } from '../dialogs/_dialog-helpers/errorHandlerDialogData';
import { ErrorHandlerComponent } from '../dialogs/error-handler/error-handler.component';
import { MatDialog } from '@angular/material/dialog';
import { ApiService } from '../_services/api.service';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    CommonModule, 
    MatInputModule, 
    MatFormFieldModule, 
    MatButtonModule, 
    FormsModule,
    MatDividerModule,
    RouterModule
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  loginModel: LoginModel
  http: HttpClient
  router: Router

  constructor(
    http: HttpClient, 
    router: Router,
    private titleService: Title,
    private dialog: MatDialog,
    private api: ApiService,
    private authService: AuthService
  ){
    titleService.setTitle('Login | YouDo')
    this.loginModel = new LoginModel()
    this.http = http
    this.router = router
  }

  public sendLoginCredentials() : void {
    this.http
    .post<TokenModel>(APP_URLS.baseUrl + APP_URLS.login, this.loginModel)
    .subscribe({
      next: (v) => {
        console.log(v)
        localStorage.setItem('username', this.loginModel.username)
        localStorage.setItem('userid', v.id)
        localStorage.setItem('token', v.token)
        localStorage.setItem('token-expiration', v.expiration.toString())
      },
      error: (e) => this.handleError(e),
      complete: () => {
        console.info('Login complete')
        this.authService.authUserListener()
        this.authService.authUser()
      }
    })
  }

  isAnyError(): boolean{
    if (this.loginModel.username.length === 0) return true
    if (this.loginModel.password.length === 0) return true
    return false
  }

  handleError(error: any){
    if(error.status === 401){
      let dialogData = new ErrorHandlerDialogData
      dialogData.title = 'Login Error'
      dialogData.description = 'This username-password pair does not exist.'
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
