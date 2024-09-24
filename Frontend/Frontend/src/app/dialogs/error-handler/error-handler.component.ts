import { Component, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogTitle, MatDialogContent, MatDialogActions, MatDialogClose, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ErrorHandlerDialogData } from '../_dialog-helpers/errorHandlerDialogData';

@Component({
  selector: 'app-error-handler',
  standalone: true,
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatButtonModule,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose,
  ],
  templateUrl: './error-handler.component.html',
  styleUrl: './error-handler.component.scss'
})
export class ErrorHandlerComponent {
  constructor(
    public dialogRef: MatDialogRef<ErrorHandlerComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ErrorHandlerDialogData,
  ) {}

  onYesClick(): void{
    this.dialogRef.close();
  }
}
