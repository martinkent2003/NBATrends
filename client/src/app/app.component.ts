import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { VisualizationComponent } from './Pages/visualization/visualization.component';
import { NavbarComponent } from './Shared/navbar/navbar.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, VisualizationComponent, NavbarComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = '';
}
