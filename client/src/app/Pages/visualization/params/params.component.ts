import { Component, OnInit } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TeamsPlayersService } from '../../../Services/teams-players.service';
import { Observable, map, startWith } from 'rxjs';
import { CommonModule } from '@angular/common';
import { QueryParams } from '../../../Models/queryParams';
import { QueryService } from '../../../Services/query.service';

@Component({
  selector: 'app-params',
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule,
    CommonModule
  ],
  templateUrl: './params.component.html',
  styleUrl: './params.component.css'
})
export class ParamsComponent implements OnInit{
  queryParams: QueryParams = new QueryParams()

  teams: String[] = []
  teams$: Observable<String[]>
  teamFilter = new FormControl('', { nonNullable: true })

  players: String[] = []
  players$: Observable<String[]>
  playerFilter = new FormControl('', { nonNullable: true })

  queryOptions: String[] = [
    'Compare First Overall Picks',
    '( Complex Query 2 )',
    '( Complex Query 3 )',
    '( Complex Query 4 )',
    '( Complex Query 5 )',
    'Custom Query',
  ]

  attributeOptions: String[] = [
    'Field Goals Made',
    'Filed Goals Attempted',
    'Field Goal Percentage',
    'Three Pointers Made',
    'Three Pointers Attempted',
    'Three Point Percentage',
    'Free Throws Made',
    'Free Throws Attempted',
    'Free Throw Percentage',
    'Offensive Rebounds',
    'Defensive Rebounds',
    'Total Rebounds',
    'Assists',
    'Steals',
    'Blocks',
    'Turnovers',
    'Personal Fouls',
    'Points',
    'Plus Minus'
  ]

  minYear: Number = 1950
  maxYear: Number = 2023

  constructor(private teamsPlayersService: TeamsPlayersService, private queryService: QueryService) {
    this.players$ = this.playerFilter.valueChanges.pipe(
      startWith(''),
      map((text) => this.filterPlayers(text))
    )

    this.teams$ = this.teamFilter.valueChanges.pipe(
      startWith(''),
      map((text) => this.filterTeams(text))
    )
  }

  ngOnInit(): void {
    this.teamsPlayersService.getTeamMap().subscribe(map => {
      for (let key of map.keys()) {
        this.teams.push(key)
      }
    })

    this.teamsPlayersService.getPlayerMap().subscribe(map => {
      for (let key of map.keys()) {
        this.players.push(key)
      }
    })
  }

  private filterPlayers(text: string): String[] {
    return this.players.filter((playerName) => {
      const term = text.toLowerCase();
      return (
        playerName.toLowerCase().includes(term)
      );
    });
  }

  private filterTeams(text: string): String[] {
    return this.teams.filter((teamName) => {
      const term = text.toLowerCase();
      return (
        teamName.toLowerCase().includes(term)
      );
    });
  }

  changeQueryOption(ind: Number) { this.queryParams.changeQueryOption(ind) }
  setSelectTeam() { this.queryParams.setSelectTeam() }
  setSelectPlayer() { this.queryParams.setSelectPlayer() }
  addPlayerToList(name: String) { this.queryParams.addPlayerToList(name) }
  addTeamToList(name: String) { this.queryParams.addTeamToList(name) }
  removePlayerFromList(name: String) { this.queryParams.removePlayerFromList(name) }
  removeTeamFromList(name: String) { this.queryParams.removeTeamFromList(name) }
  chooseAttribute(ind: number, name: String) { this.queryParams.chooseAttribute(ind, name) }

  onGenerateGraph() {
    this.queryService.updateQueryParams(this.queryParams)
  }

}
