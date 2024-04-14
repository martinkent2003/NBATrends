import { Component, OnInit } from '@angular/core';
import { CanvasJSAngularChartsModule } from '@canvasjs/angular-charts';
import { LineData } from '../../Models/dataPoint';
import { QueryService } from '../../Services/query.service';
import { ParamsComponent } from './params/params.component';

@Component({
    selector: 'app-visualization',
    standalone: true,
    templateUrl: './visualization.component.html',
    styleUrl: './visualization.component.css',
    imports: [CanvasJSAngularChartsModule, ParamsComponent]
})
export class VisualizationComponent implements OnInit{

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

	constructor(private queryService: QueryService) {}

	ngOnInit(): void {
		this.getData()
	}

	getData() {
		const newChartData: LineData[] = []
		newChartData.push(this.queryService.getTeamStatYearly(1, "Points", 2000, 2010))
		newChartData.push(this.queryService.getTeamStatYearly(2, "Points", 2000, 2010))
		newChartData.push(this.queryService.getTeamStatYearly(3, "Points", 2000, 2010))
		this.chartOptions.data = newChartData as never[];
	}
}
