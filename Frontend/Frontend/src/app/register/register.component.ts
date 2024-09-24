import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatGridListModule} from '@angular/material/grid-list';
import { MatButtonModule } from '@angular/material/button';
import { Router, RouterModule } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { RegisterModel } from '../_models/registermodel';
import { APP_URLS } from '../app.urls';
import { FormsModule } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { ErrorHandlerDialogData } from '../dialogs/_dialog-helpers/errorHandlerDialogData';
import { ErrorHandlerComponent } from '../dialogs/error-handler/error-handler.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    CommonModule, 
    MatInputModule, 
    MatFormFieldModule, 
    MatGridListModule, 
    MatButtonModule, 
    FormsModule,
    RouterModule
  ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {
  router: Router
  http: HttpClient
  registerModel: RegisterModel

  constructor(
    router: Router, 
    http: HttpClient,
    private titleService: Title,
    private dialog: MatDialog
  ){
    titleService.setTitle('Register | YouDo')
    this.router = router
    this.http = http
    this.registerModel = new RegisterModel()
  }

  public sendRegisterCredentials() : void {
    this.http.put(APP_URLS.baseUrl + APP_URLS.register, this.registerModel)
    .subscribe({
      next: (r) => this.handleError(r),
      error: (e) => this.handleError(e),
      complete: () => {
        console.info('complete') 
      }
    })
  }

  isAnyError(): boolean{
    if (this.registerModel.email.length === 0) return true
    if (this.registerModel.firstName.length === 0) return true
    if (this.registerModel.lastName.length === 0) return true
    if (this.registerModel.username.length === 0) return true
    if (this.registerModel.password.length === 0) return true

    return false
  }

  handleError(error: any){
    if(error === null){
      let dialogData = new ErrorHandlerDialogData
      dialogData.title = 'Success!'
      dialogData.description = 'Register was successful. To continue please sign in.'
      dialogData.color = 'primary'
      this.openSuccessDialog(dialogData)
    }
    else if(error.status === 400){
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
  }

  openSuccessDialog(dialogData: ErrorHandlerDialogData): void{
    const dialogRef = this.dialog.open(ErrorHandlerComponent, {
      data: dialogData,
    });

    dialogRef.afterClosed().subscribe(result => {
      dialogData = result
      console.log('The dialog was closed');
      console.log(dialogData);
      this.router.navigate(['/login'])
    });
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
