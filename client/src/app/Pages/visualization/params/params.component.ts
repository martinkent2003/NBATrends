import { Component, OnInit } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TeamsPlayersService } from '../../../Services/teams-players.service';
import { Observable, map, startWith } from 'rxjs';
import { CommonModule } from '@angular/common';
import { QueryParams } from '../../../Models/queryParams';

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
  queryParams: QueryParams = {
    selectTeam: true,
    selectPlayer: false,
    teamsSelected: [],
    playersSelected: []
  }

  teams: String[] = []
  teams$: Observable<String[]>
  teamFilter = new FormControl('', { nonNullable: true })

  players: String[] = []
  players$: Observable<String[]>
  playerFilter = new FormControl('', { nonNullable: true })

  constructor(private teamsPlayersService: TeamsPlayersService) {
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

  setSelectTeam() {
    this.queryParams.selectTeam = true;
    this.queryParams.selectPlayer = false;
  }

  setSelectPlayer() {
    this.queryParams.selectTeam = false;
    this.queryParams.selectPlayer = true;
  }

  addPlayerToList(name: String) {
    const index = this.queryParams.playersSelected.indexOf(name, 0);
    if (index == -1) {
      this.queryParams.playersSelected.push(name)
    }
  }

  addTeamToList(name: String) {
    const index = this.queryParams.teamsSelected.indexOf(name, 0);
    if (index == -1) {
      this.queryParams.teamsSelected.push(name)
    }
  }

  removePlayerFromList(name: String) {
    const index = this.queryParams.playersSelected.indexOf(name, 0);
    if (index > -1) {
      this.queryParams.playersSelected.splice(index, 1);
    }
  }

  removeTeamFromList(name: String) {
    const index = this.queryParams.teamsSelected.indexOf(name, 0);
    if (index > -1) {
      this.queryParams.teamsSelected.splice(index, 1);
    }
  }

  onGenerateGraph() {
    console.log(this.queryParams.playersSelected)
    console.log(this.queryParams.teamsSelected)
  }
}
