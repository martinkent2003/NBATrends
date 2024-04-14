import { Component, OnInit } from '@angular/core';
import { TeamsPlayersService } from '../../Services/teams-players.service';
import { ChartComponent } from '../visualization/chart/chart.component';

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [ChartComponent],
  templateUrl: './form.component.html',
  styleUrl: './form.component.css'
})
export class FormComponent implements OnInit{
  constructor(private teamsPlayersService: TeamsPlayersService) {}

  ngOnInit(): void {
    
  }

}
