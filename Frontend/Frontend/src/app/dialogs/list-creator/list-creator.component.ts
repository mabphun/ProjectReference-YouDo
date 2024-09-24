import { Component, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogActions, MatDialogClose, MatDialogContent, MatDialogRef, MatDialogTitle } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { ListCreatorDialogData } from '../_dialog-helpers/listCreatorDialogData';

@Component({
  selector: 'app-list-creator',
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
    MatIconModule,
  ],
  templateUrl: './list-creator.component.html',
  styleUrl: './list-creator.component.scss'
})
export class ListCreatorComponent {
  constructor(
    public dialogRef: MatDialogRef<ListCreatorComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ListCreatorDialogData,
  ) {}

  isAnyError(): boolean{
    if(this.data.list.name === '') return true
    if(this.data.list.description === '') return true

    return false
  }

  onYesClick(): void{
    this.data.result = true
    this.dialogRef.close(this.data);
  }

  onNoClick(): void {
    this.data.result = false
    this.dialogRef.close(this.data);
  }
}
