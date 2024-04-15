import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { QueryParams } from "../Models/queryParams";
import { BehaviorSubject, Observable } from "rxjs";
import { SeasonAverageAttribute } from "../Models/DTO/seasonAverageAttribute";
import { firstPicksAverageAttribute } from "../Models/DTO/firstPicksAverageAttribute";
import { PtsPerDecadeSeasonal } from "../Models/DTO/ptsPerDecadeSeasonal";

@Injectable({providedIn: 'root'})
export class QueryService {
  baseUrl = 'https://localhost:5001/api/'
  mainQueryParams: QueryParams = new QueryParams()
  mainQueryParams$: BehaviorSubject<QueryParams> = new BehaviorSubject<QueryParams>(this.mainQueryParams)

  presetComplexQueries: string[] = [
    this.baseUrl + 'drafthistories/firstOverallPicksCarreerAverage/attribute/',
    this.baseUrl + 'games/AvgPointsPerDecadeSeasonal',
    this.baseUrl + 'PlayerBoxScore/yearlyAveragePerPositionStats/attribute/'
  ]

  constructor(private http: HttpClient) { }

  getComplexQuery0(attribute: String) {
    return this.http.get<firstPicksAverageAttribute[]>(this.presetComplexQueries[0] + attribute)
  }

  getComplexQuery1() {
    return this.http.get<PtsPerDecadeSeasonal[]>(this.presetComplexQueries[1])
  }

  getComplexQuery2(attribute: String, position: String) {
    return this.http.get<SeasonAverageAttribute[]>(this.presetComplexQueries[2] + attribute + '/position/' + position)
  }

  getTeamStatYearly(teamId: Number, stat: String, fromYear: Number, toYear: Number) : Observable<SeasonAverageAttribute[]> {
    return this.http.get<SeasonAverageAttribute[]>(this.baseUrl + 'games/yearlyAverage/attribute/' + stat + '/team/'+ teamId +'/fromYear/' + fromYear + '/toYear/' + toYear)
  }

  getPlayerStatYearly(playerId: Number, stat: String) {
    return this.http.get<SeasonAverageAttribute[]>(this.baseUrl + 'players/yearlyAverages/playerId/' + playerId + '/attribute/' + stat)
  }

  updateQueryParams(newParams: QueryParams) {
    this.mainQueryParams = newParams
    this.mainQueryParams$?.next(newParams)
  }

  sendQueryParams() {
    this.mainQueryParams$?.next(this.mainQueryParams)
  }
}
