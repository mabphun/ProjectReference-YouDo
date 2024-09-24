import { Component, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  MatDialog,
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatDialogTitle,
  MatDialogContent,
  MatDialogActions,
  MatDialogClose,
} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { CheckDecisionDialogData } from '../_dialog-helpers/checkDecisionDialogData';

@Component({
  selector: 'app-decision-check',
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
  templateUrl: './decision-check.component.html',
  styleUrl: './decision-check.component.scss'
})
export class DecisionCheckComponent {
  constructor(
    public dialogRef: MatDialogRef<DecisionCheckComponent>,
    @Inject(MAT_DIALOG_DATA) public data: CheckDecisionDialogData,
  ) {}

  onYesClick(): void{
    this.data.result = true
    this.dialogRef.close(this.data);
  }

  onNoClick(): void {
    this.data.result = false
    this.dialogRef.close(this.data);
  }
}
