import { Component } from '@angular/core';
import { ParamsComponent } from './params/params.component';
import { ChartComponent } from './chart/chart.component';

@Component({
    selector: 'app-visualization',
    standalone: true,
    templateUrl: './visualization.component.html',
    styleUrl: './visualization.component.css',
    imports: [ChartComponent, ParamsComponent]
})
export class VisualizationComponent {
	
}
