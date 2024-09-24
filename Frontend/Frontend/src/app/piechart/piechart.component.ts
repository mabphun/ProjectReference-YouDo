import { Component, Inject, PLATFORM_ID, ViewChild, inject } from '@angular/core';
import { CommonModule, isPlatformBrowser } from '@angular/common';
import { ApiService } from '../_services/api.service';
import { UserWorkLogService } from '../_services/userworklog.service';
import { BaseChartDirective } from 'ng2-charts';
import { ChartConfiguration, ChartOptions, ChartType } from 'chart.js';
import { UserWorkLogDto } from '../_dtos/userWorkLogDto';
import { DateConverter } from '../_services/date.converter';
import moment from 'moment';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-piechart',
  standalone: true,
  imports: [
    CommonModule, 
    BaseChartDirective,
    MatButtonModule,
  ],
  templateUrl: './piechart.component.html',
  styleUrl: './piechart.component.scss'
})
export class PiechartComponent {
  api = inject(ApiService)
  _userWorkLogService: UserWorkLogService
  isBrowser: boolean
  uwlList: Array<UserWorkLogDto>
  _dateConverter = inject(DateConverter)
  isInSummaryMode: boolean

  filterDay: number
  filteredList: Array<UserWorkLogDto>

  @ViewChild(BaseChartDirective) _chart?: BaseChartDirective;

  
  lineChartType: ChartType = 'line';
  lineChartData: ChartConfiguration['data'] = {
    datasets: [
      {
        data: []
      }
    ]
  }
  lineChartOptions: ChartConfiguration['options'] = {
    responsive: true
  };
  

  constructor(
    @Inject(PLATFORM_ID) private platformId: any,
    userWorkLogService: UserWorkLogService
  ) {
    this.isBrowser = true
    this._userWorkLogService = userWorkLogService
    this.uwlList = []
    this.filterDay = 30
    this.filteredList = []
    this.isInSummaryMode = true
  }

  ngOnInit():void {
    this.isBrowser = isPlatformBrowser(this.platformId)

    this.filter(this.filterDay)
  }

  changeMode(){
    this.isInSummaryMode = !this.isInSummaryMode
    this.filter(this.filterDay)
  }

  getChangeModeButtonText():string{
    if (this.isInSummaryMode){
      return 'Summary'
    }
    else{
      return 'All Worklog'
    }
  }

  filter(num: number){
    this.filterDay = num
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

        this.uwlList.forEach(element => {
          let diff = rightNow.diff(moment.utc(element.logDate), 'day')
          if (diff < this.filterDay){
            if (!this.isInSummaryMode){
              this.filteredList.push(element)
            }
            else{
              let uwl = this.filteredList.find(x=> x.taskItem.id === element.taskItem.id)
              if (uwl !== undefined){

                //console.log('UWL értéke: ' + uwl.workTimeInMins + ', hozzáadunk: ' + element.workTimeInMins);
                
                uwl.workTimeInMins = uwl.workTimeInMins + element.workTimeInMins
                //console.log('ÚJ UWL ÉRTÉK: ' + uwl.workTimeInMins);         
                
              }
              else{
                this.filteredList.push(element)
              }
            }
          }
        });
        //console.log(this.filteredList);
        this.createPieChart(this.filteredList)
      }
    })

  }

  createPieChart(userWorkLogs: Array<UserWorkLogDto>){
    // Pie

    //console.log(userWorkLogs);
    

    let datasets: any[] = []
    let dataset: any = {
      data: new Array<number>,
      label: '',
      //fill: true,
      //tension: 0.5,
      //borderColor: 'black',
      //backgroundColor: 'rgba(255,0,0,0.3)'
    }
    let labels: string[] = []

    userWorkLogs.forEach(uwl =>{
      let rounded = Math.round((uwl.workTimeInMins / 60) * 10) / 10
      dataset.data.push(rounded)
      labels.push(uwl.taskItem.title)
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

    let pieChartOptions: ChartOptions<'pie'> = {
      responsive: false,
    };
    let pieChartLabels = [ [ 'Download', 'Sales' ], [ 'In', 'Store', 'Sales' ], 'Mail Sales' ];
    let pieChartDatasets = [ {
      data: [ 300, 500, 100 ]
    } ];
    let pieChartLegend = true;
    let pieChartPlugins = [];



    this._chart.type = 'pie'
    this._chart.labels = pieChartLabels
    this._chart.datasets = pieChartDatasets
    //this._pieChart?.update('none')
    this._chart?.update()
    
  }


  getUsersWorkLog() {
    
  }
}
