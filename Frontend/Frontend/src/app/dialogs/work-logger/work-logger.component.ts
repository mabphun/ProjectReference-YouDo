import { Component, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormControl, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogActions, MatDialogClose, MatDialogContent, MatDialogRef, MatDialogTitle } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { WorkLoggerDialogData } from '../_dialog-helpers/workLoggerDialogData';
import {MatTooltipModule} from '@angular/material/tooltip';

@Component({
  selector: 'app-work-logger',
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
    ReactiveFormsModule,
    // MatDatepickerModule,
    // MatMomentDateModule,
    // MatSelectModule,
    MatIconModule,
    MatTooltipModule
  ],
  templateUrl: './work-logger.component.html',
  styleUrl: './work-logger.component.scss'
})
export class WorkLoggerComponent {

  inputText: string
  invalidFormatError = false
  calculatedTime: Array<string> = ['', '', '']

  constructor(
    public dialogRef: MatDialogRef<WorkLoggerComponent>,
    @Inject(MAT_DIALOG_DATA) public data: WorkLoggerDialogData,
  ) {
    this.inputText = ''    
  }

  getValue(event: Event): string {
    return (event.target as HTMLInputElement).value;
  }

  check(input: string){
    this.convertTime(input)
  }

  getEstimatedTime(): string {
    if (this.data.estimatedHours === 0){
      return "Estimation could not be made, because there was no changes to the task."
    }
    let rounded = Math.round(this.data.estimatedHours * 10) / 10

    return "Your estimated work time is " + rounded + " hours"
  }

  getTimeFromString(substring: string) : number{
    if (substring.includes('d')){
      //napok száma
      let index = substring.indexOf('d')
      if (index == 0){
        return 0
      }
      let sub = substring.substring(0, index)
      sub = sub.trim()
      //console.log(sub + ' nap');
      this.calculatedTime[0] = sub
      let time: number = +sub
      time = time* 3600
      return time
    }
    else if (substring.includes('h')){
      //órák száma
      let index = substring.indexOf('h')
      if (index == 0){
        return 0
      }
      let sub = substring.substring(0, index)
      sub = sub.trim()
      //console.log(sub + ' óra');
      let time: number = +sub
      this.calculatedTime[1] = sub
      time = time* 60
      return time
    }
    else if (substring.includes('m')){
      //percek száma
      let index = substring.indexOf('m')
      if (index == 0){
        return 0
      }
      let sub = substring.substring(0, index)
      sub = sub.trim()
      //console.log(sub + ' perc');
      this.calculatedTime[2] = sub
      let time: number = +sub
      return time
    }
    else{
      //hiba
      return 0
    }
  }

  showInvalidFormatError(){
    this.data.time = 0
    this.invalidFormatError = true
  }

  convertTime(input: string){
    this.calculatedTime = ['', '', '']
    let totalMinutes = 0
    if (!input.includes('d') && !input.includes('h') && !input.includes('m')){
      this.showInvalidFormatError()
      return
    }
    else if (input.includes(';')){
      //több inputos feldolgozás
      let inputs = input.split(';')
      //console.log(inputs);
      
      for (let i = 0; i < inputs.length; i++) {
        const sub = inputs[i];
        if (sub.length > 0){
          let time = this.getTimeFromString(sub)
          if (time === 0 || Number.isNaN(time)) {
            this.showInvalidFormatError()
            return
          }
          //console.log(time);
          totalMinutes += time
        }
      }
    }
    else{
      //egy inputos feldolgozás
      let time = this.getTimeFromString(input)
      if (time === 0 || Number.isNaN(time)){
        this.showInvalidFormatError()
        return
      }
      totalMinutes += time
    }
    //console.log(time);
    console.log(totalMinutes);
    this.data.time = totalMinutes
    this.invalidFormatError = false
    
    return input
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
