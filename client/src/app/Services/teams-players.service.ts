import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Team } from '../Models/team';
import { Player } from '../Models/player';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class TeamsPlayersService {
    teams: Team[] = []
    teamNameToId = new Map<String, Number>();
    playerNameToId = new Map<String, Number>();
    private teamMap$: BehaviorSubject<Map<String, Number>> = new BehaviorSubject(this.teamNameToId)
    private playerMap$: BehaviorSubject<Map<String, Number>> = new BehaviorSubject(this.playerNameToId)

    baseUrl = 'https://localhost:5001/api/'

    constructor(private http: HttpClient) { }

    startService(): void {
        this.loadTeams()
        this.loadPlayers()
    }

    private loadTeams() {
        this.http.get<Team[]>(this.baseUrl + 'teams').subscribe({
            next: res => {
                this.teams = res;
                this.teams.forEach(team => {
                    this.teamNameToId.set(team.fullName, team.teamId)
                })
                this.teamMap$.next(this.teamNameToId)
            },
            error: err => console.log(err)
        })
    }

    private loadPlayers() {
        this.http.get<Player[]>(this.baseUrl + 'players').subscribe({
            next: res => {
                res.forEach(player => {
                    this.playerNameToId.set(player.firstName + ' ' + player.lastName, player.personId)
                })
                this.playerMap$.next(this.playerNameToId)
            },
            error: err => console.log(err)
        })
    }

    // Public Functions

    getTeamMap() : Observable<Map<String, Number>> {
        return this.teamMap$
    }

    getPlayerMap() : Observable<Map<String, Number>> {
        return this.playerMap$
    }
    
}
