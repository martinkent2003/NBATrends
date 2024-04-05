import { Component } from '@angular/core';
import { VisualizationComponent } from '../visualization/visualization.component';

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [VisualizationComponent],
  templateUrl: './form.component.html',
  styleUrl: './form.component.css'
})
export class FormComponent {

}
