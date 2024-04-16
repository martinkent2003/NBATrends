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
    this.baseUrl + 'games/AvgAttributePerDecadeSeasonal/attribute/',
    this.baseUrl + 'PlayerBoxScore/yearlyAveragePerPositionStats/attribute/',
    this.baseUrl + 'PlayerBoxScore/AvgAttributeByHeight/attribute/',
    this.baseUrl + 'games/yearlyOverStatByPosition/attribute/',
    this.baseUrl + 'games/yearlyOverStatByPositionRatio/attribute/'
  ]

  constructor(private http: HttpClient) { }

  getComplexQuery0(attribute: String) {
    return this.http.get<firstPicksAverageAttribute[]>(this.presetComplexQueries[0] + attribute)
  }

  getComplexQuery1(attribute: String) {
    return this.http.get<PtsPerDecadeSeasonal[]>(this.presetComplexQueries[1] + attribute)
  }

  getComplexQuery2(attribute: String, position: String) {
    return this.http.get<SeasonAverageAttribute[]>(this.presetComplexQueries[2] + attribute + '/position/' + position)
  }

  getComplexQuery3(attribute: String){
    return this.http.get<PtsPerDecadeSeasonal[]>(this.presetComplexQueries[3] + attribute)
  }

  getComplexQuery4(attribute: String, position: String, value: Number) {
    return this.http.get<SeasonAverageAttribute[]>(this.presetComplexQueries[4] + attribute + '/statistic/' + value + '/position/' + position)
  }

  getComplexQuery4Percentage(attribute: String, position: String, value: Number) {
    return this.http.get<SeasonAverageAttribute[]>(this.presetComplexQueries[5] + attribute + '/statistic/' + value + '/position/' + position)
  }

  getTeamStatYearly(teamId: Number, stat: String, fromYear: Number, toYear: Number) : Observable<SeasonAverageAttribute[]> {
    return this.http.get<SeasonAverageAttribute[]>(this.baseUrl + 'games/yearlyAverage/attribute/' + stat + '/team/'+ teamId +'/fromYear/' + fromYear + '/toYear/' + toYear)
  }

  getTeamStatYearlyHome(teamId: Number, stat: String, fromYear: Number, toYear: Number) : Observable<SeasonAverageAttribute[]> {
    return this.http.get<SeasonAverageAttribute[]>(this.baseUrl + 'games/homeGames/attribute/' + stat + '/team/'+ teamId +'/fromYear/' + fromYear + '/toYear/' + toYear)
  }

  getTeamStatYearlyAway(teamId: Number, stat: String, fromYear: Number, toYear: Number) : Observable<SeasonAverageAttribute[]> {
    return this.http.get<SeasonAverageAttribute[]>(this.baseUrl + 'games/awayGames/attribute/' + stat + '/team/'+ teamId +'/fromYear/' + fromYear + '/toYear/' + toYear)
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
