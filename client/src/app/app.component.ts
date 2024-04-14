import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { VisualizationComponent } from './Pages/visualization/visualization.component';
import { NavbarComponent } from './Shared/navbar/navbar.component';
import { TeamsPlayersService } from './Services/teams-players.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, VisualizationComponent, NavbarComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  constructor(private teamsPlayersService: TeamsPlayersService) {}

  ngOnInit(): void {
    this.teamsPlayersService.startService();
  }

  title = '';
}
