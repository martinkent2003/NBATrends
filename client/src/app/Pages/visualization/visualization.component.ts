import { Component } from '@angular/core';
import { CanvasJSAngularChartsModule } from '@canvasjs/angular-charts';

@Component({
  selector: 'app-visualization',
  standalone: true,
  imports: [CanvasJSAngularChartsModule],
  templateUrl: './visualization.component.html',
  styleUrl: './visualization.component.css'
})
export class VisualizationComponent {
  chartOptions = {
		animationEnabled: true,
		theme: "light2",
		title: {
			text: "Points"
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
		data: [{
			type:"line",
			name: "Lebron James",
			showInLegend: true,
			yValueFormatString: "",
			dataPoints: [		
				{ x: 2010, y: 27, label: "2010" },
				{ x: 2011, y: 28, label: "2011" },
				{ x: 2012, y: 35, label: "2012" },
				{ x: 2013, y: 45, label: "2013" },
				{ x: 2014, y: 54, label: "2014" },
				{ x: 2015, y: 64, label: "2015" },
				{ x: 2016, y: 69, label: "2016" },
				{ x: 2017, y: 68, label: "2017" },
				{ x: 2018, y: 61, label: "2018" },
				{ x: 2019, y: 50, label: "2019" },
				{ x: 2020, y: 41, label: "2020" },
				{ x: 2021, y: 33, label: "2021" }
			]
		},
		{
			type: "line",
			name: "Kevin Durant",
			showInLegend: true,
			yValueFormatString: "",
			dataPoints: [
				{ x: 2010, y: 40, label: "2010" },
				{ x: 2011, y: 42, label: "2011" },
				{ x: 2012, y: 50, label: "2012" },
				{ x: 2013, y: 62, label: "2013" },
				{ x: 2014, y: 72, label: "2014" },
				{ x: 2015, y: 80, label: "2015" },
				{ x: 2016, y: 85, label: "2016" },
				{ x: 2017, y: 84, label: "2017" },
				{ x: 2018, y: 76, label: "2018" },
				{ x: 2019, y: 64, label: "2019" },
				{ x: 2020, y: 54, label: "2020" },
				{ x: 2021, y: 44, label: "2021" }
			]
		}]
	}	
}
