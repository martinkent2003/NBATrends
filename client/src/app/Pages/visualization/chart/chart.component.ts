import { AfterViewInit, Component, Input, OnInit } from '@angular/core';
import { CanvasJSAngularChartsModule, CanvasJSChart } from '@canvasjs/angular-charts';
import { ParamsComponent } from '../params/params.component';
import { QueryService } from '../../../Services/query.service';
import { DataPoint, LineData } from '../../../Models/dataPoint';
import { QueryParams } from '../../../Models/queryParams';
import { Observable } from 'rxjs';
import { TeamsPlayersService } from '../../../Services/teams-players.service';

@Component({
  selector: 'app-chart',
  standalone: true,
  imports: [CanvasJSAngularChartsModule, ParamsComponent],
  templateUrl: './chart.component.html',
  styleUrl: './chart.component.css'
})
export class ChartComponent implements OnInit, AfterViewInit{
  @Input() queryNumber: Number = 0
  mainQueryParams: QueryParams = new QueryParams()
  mainQueryParamsObservable?: Observable<QueryParams>

  chartRendered: Boolean = false;
  chart: any
  chartOptions = {
		animationEnabled: true,
		theme: "light2",
		title: {
			text: ""
		},
		axisX: {
			interval: 1
		},
		axisY: {
			title: "Points",
		    suffix: ""
		},
		toolTip: {
			shared: true
		},
		legend: {
			cursor: "pointer",
			itemclick: function(e: any){
				if (typeof(e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
					e.dataSeries.visible = false;
				} else{
					e.dataSeries.visible = true;
				}
				e.chart.render();
			}
		},
		data: []
	}

	constructor(private queryService: QueryService, private teamsPlayersService: TeamsPlayersService) {

  }

	ngOnInit(): void {
    this.queryService.mainQueryParams$?.subscribe({
      next: (params: QueryParams) => {
        this.mainQueryParams = params
        this.getData()
        if (this.chartRendered) this.chart.render()
      }
    })
	}

	getData() {
    if (this.queryNumber == -1) {
      this.handleQuery(this.mainQueryParams)
    }
    else {
      const newChartData: LineData[] = []
		  this.chartOptions.data = newChartData as never[];
    }

	}

  getChartInstance(chart: object) {
    this.chart = chart
  }

  ngAfterViewInit() {
    this.getData();
    this.chart.render();
    this.chartRendered = true;
  }

  handleQuery(queryParams: QueryParams){
    this.chartOptions.data = []

    // Custom Query: TEAM Yearly Data
    switch (queryParams.queryOption) {
      case 0:
        this.chartOptions.axisY.title = queryParams.attributeOptionDisplay as string
        this.queryService.getComplexQuery0(queryParams.attributeOptions.at(queryParams.attributeSelected)!).subscribe({
          next: res => {
            var dataPointArray: DataPoint[] = []
            for (let data of res) {
              let dp: DataPoint = {x: data.seasonId, y: data.avgAttribute, label: String(data.seasonId) + data.firstName + ' ' + data.lastName}
              dataPointArray.push(dp)
            }
            var lineData: LineData = {
              type: "line",
              showInLegend: true,
              name: queryParams.attributeOptionDisplay,
              dataPoints: dataPointArray
            }
            this.chartOptions.data.push(lineData as never)
            if (this.chartRendered) this.chart.render()
          },
          error: err => console.log(err)
        })
        break;

      case 5:
        this.handleCustomQuery(queryParams)
        break;

      default:
        console.log('Nothing')
    }
    
  }

  handleCustomQuery (queryParams: QueryParams) {
    if (queryParams.selectTeam) {
      this.chartOptions.axisY.title = queryParams.attributeOptionDisplay as string
      for (let teamName of queryParams.teamsSelected) {
        this.queryService.getTeamStatYearly(this.teamsPlayersService.teamNameToId.get(teamName)!, queryParams.attributeOptions[queryParams.attributeSelected], queryParams.fromYear, queryParams.toYear).subscribe({
          next: res => {
            var dataPointArray: DataPoint[] = []
            for (let stat of res) {
              let dp: DataPoint = {x: stat.year, y: stat.avgAttribute, label: String(stat.year)}
              dataPointArray.push(dp)
            }
            var teamLineData: LineData = {
              type: "line",
              showInLegend: true,
              name: teamName,
              dataPoints: dataPointArray
            }
            this.chartOptions.data.push(teamLineData as never)
            if (this.chartRendered) this.chart.render()
          },
          error: err => console.log(err)
        })
      }
    }

    // Custon Query: PLAYER Yearly Data
    else if (queryParams.selectPlayer) {
      this.chartOptions.axisY.title = queryParams.attributeOptionDisplay as string
      for (let playerName of queryParams.playersSelected) {
        this.queryService.getPlayerStatYearly(this.teamsPlayersService.playerNameToId.get(playerName)!, queryParams.attributeOptions[queryParams.attributeSelected]).subscribe({
          next: res => {
            var dataPointArray: DataPoint[] = []
            for (let stat of res) {
              let dp: DataPoint = {x: stat.year, y: stat.avgAttribute, label: String(stat.year)}
              dataPointArray.push(dp)
            }
            var teamLineData: LineData = {
              type: "line",
              showInLegend: true,
              name: playerName,
              dataPoints: dataPointArray
            }
            this.chartOptions.data.push(teamLineData as never)
            if (this.chartRendered) this.chart.render()
          },
          error: err => console.log(err)
        })  
      }
    }
  }
}
