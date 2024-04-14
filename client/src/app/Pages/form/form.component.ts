import { Component, OnInit } from '@angular/core';
import { VisualizationComponent } from '../visualization/visualization.component';
import { TeamsPlayersService } from '../../Services/teams-players.service';

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [VisualizationComponent],
  templateUrl: './form.component.html',
  styleUrl: './form.component.css'
})
export class FormComponent implements OnInit{
  constructor(private teamsPlayersService: TeamsPlayersService) {}

  ngOnInit(): void {
    
  }

}
