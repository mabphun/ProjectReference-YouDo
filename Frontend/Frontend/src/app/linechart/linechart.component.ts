import { Component, Inject, PLATFORM_ID, ViewChild, inject } from '@angular/core';
import { CommonModule, isPlatformBrowser } from '@angular/common';
import { ApiService } from '../_services/api.service';
import { UserWorkLogService } from '../_services/userworklog.service';
import { BaseChartDirective } from 'ng2-charts';
import { ChartConfiguration, ChartOptions, ChartType } from 'chart.js';
import { MatButtonModule } from '@angular/material/button';
import moment from 'moment';
import { UserWorkLogDto } from '../_dtos/userWorkLogDto';

@Component({
  selector: 'app-linechart',
  standalone: true,
  imports: [
    CommonModule,
    BaseChartDirective,
    MatButtonModule,
  ],
  templateUrl: './linechart.component.html',
  styleUrl: './linechart.component.scss'
})
export class LinechartComponent {
  @ViewChild(BaseChartDirective) _chart?: BaseChartDirective;
  api = inject(ApiService)
  _userWorkLogService: UserWorkLogService
  isBrowser: boolean
  filteredList: Array<UserWorkLogDto>
  uwlList: Array<UserWorkLogDto>
  numberOfWeeks: number

  constructor(
    @Inject(PLATFORM_ID) private platformId: any,
    userWorkLogService: UserWorkLogService
  ) {
    this.isBrowser = true
    this._userWorkLogService = userWorkLogService
    this.numberOfWeeks = 0
    this.filteredList = []
    this.uwlList = []
  }

  ngOnInit():void {
    this.isBrowser = isPlatformBrowser(this.platformId)

    this.filter(this.numberOfWeeks)
/*
    let userid = this.api.getUserId()
    this._userWorkLogService.getUsersWorkLog(userid)
    .subscribe({
      next: (r) => {
        //console.log(r);

        //this.createPieChart()
        let datasets: any[] = []
        let dataset: any = {
          data: new Array<number>,
          label: '',
          //fill: true,
          //tension: 0.5,
          //borderColor: 'black',
          //backgroundColor: 'rgba(255,0,0,0.3)'
        }
        r.forEach(uwl =>{
          dataset.data.push(uwl.workTimeInMins)
        })
        dataset.label = 'Task name'
        datasets.push(dataset)

        //console.log(datasets);
        

        this.lineChartData = {
          labels: ['asd', 'asd'],
          datasets
        }
        this._chart?.update()
      },
      error: (e) => {},
      complete: () => {
        
      }
    })
    */
  }

  getStartDate() : string{
    if (this.filteredList.length > 0){
      return this.filteredList[0].logDate
    }
    return 'start of the week'
  }

  getEndDate(): string{
    if (this.filteredList.length > 0){
      return this.filteredList[this.filteredList.length-1]?.logDate
    }
    return 'end of the week'
  }

  filter(num: number){
    this.numberOfWeeks = this.numberOfWeeks + num
    this.filteredList.splice(0, this.filteredList.length)  
    this.uwlList.splice(0, this.uwlList.length)
    //console.log(this.filteredList);

    let userid = this.api.getUserId()
    this._userWorkLogService.getUsersWorkLog(userid)
    .subscribe({
      next: (r) => {
        //console.log(r);
        r.forEach(uwl => this.uwlList.push(uwl))
        //console.log(this.uwlList);
        //this.createPieChart(r)        
      },
      error: (e) => {},
      complete: () => {
        let rightNow = moment.utc()
        //console.log(rightNow.toJSON());

        this.uwlList.forEach(element => {
          let diff = rightNow.diff(moment.utc(element.logDate), 'weeks')
          //console.log(diff);
          
          if (diff === this.numberOfWeeks){            
            let uwl = this.filteredList.find(x=> 
              moment.utc(x.logDate, 'YYYY.MM.DD').format('YYYY.MM.DD') ===
              moment.utc(element.logDate).format('YYYY.MM.DD')
            )
            if (uwl !== undefined){
              uwl.workTimeInMins = uwl.workTimeInMins + element.workTimeInMins              
            }
            else{
              element.logDate = moment.utc(element.logDate).format('YYYY.MM.DD')
              this.filteredList.push(element)
            }
          }
        });

        for (let i = 0; i < 7; i++) {
          let rightNowRef = rightNow.format('YYYY.MM.DD')
          let date = moment.utc(rightNowRef, 'YYYY.MM.DD').subtract(this.numberOfWeeks, 'week').subtract(i, 'day').format('YYYY.MM.DD')
          let uwl = this.filteredList.find(x=> 
            moment.utc(x.logDate, 'YYYY.MM.DD').format('YYYY.MM.DD') === date)
          if (uwl === undefined){
            uwl = new UserWorkLogDto()
            uwl.logDate = date
            uwl.workTimeInMins = 0
            this.filteredList.push(uwl)
          }
        }

        //console.log(this.filteredList);
        this.createLineChart(this.filteredList)
      }
    })
  }

  createLineChart(userWorkLogs: Array<UserWorkLogDto>){
    userWorkLogs.sort(function (left, right) {
      return moment.utc(left.logDate, 'YYYY.MM.DD').diff(moment.utc(right.logDate, 'YYYY.MM.DD'))
    })
    //console.log(userWorkLogs);
    /*
    userWorkLogs.forEach(x=> {
      console.log(x.logDate);
    })
    */

    // Line
    let datasets: any[] = []
    let dataset: any = {
      data: new Array<number>,
      label: '',
      fill: true,
      //tension: 0.5,
      //borderColor: 'black',
      //backgroundColor: 'rgba(255,0,0,0.3)'
    }
    let labels: string[] = []

    userWorkLogs.forEach(uwl =>{
      let rounded = Math.round((uwl.workTimeInMins / 60) * 10) / 10
      dataset.data.push(rounded)
      labels.push(uwl.logDate)
    })
    dataset.label = 'Worked hours'
    datasets.push(dataset)


    this.lineChartData = {
      labels: labels,
      datasets
    }
    this._chart?.update()
     
    if (this._chart === undefined){
      //console.log('Chart is undefined');
      return
    }
    else{
      console.log('Chart is ready');
    }
    let chartLabels = [ [ 'Download', 'Sales' ], [ 'In', 'Store', 'Sales' ], 'Mail Sales' ];
    let chartDatasets = [ {
      data: [ 300, 500, 100 ]
    } ];

    this._chart.type = 'pie'
    this._chart.labels = chartLabels
    this._chart.datasets = chartDatasets
    //this._pieChart?.update('none')
    this._chart?.update()
    
  }

  lineChartType: ChartType = 'line';
  lineChartData: ChartConfiguration['data'] = {
    datasets: [
      {
        data: []
      }
    ]
  }
  options: ChartConfiguration['options'] = {
    responsive: true
  };

}
