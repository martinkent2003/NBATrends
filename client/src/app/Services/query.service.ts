import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { QueryParams } from "../Models/queryParams";
import { BehaviorSubject, Observable } from "rxjs";
import { SeasonAverageAttribute } from "../Models/DTO/seasonAverageAttribute";

@Injectable({providedIn: 'root'})
export class QueryService {
  baseUrl = 'https://localhost:5001/api/'
  mainQueryParams: QueryParams = new QueryParams()
  mainQueryParams$: BehaviorSubject<QueryParams> = new BehaviorSubject<QueryParams>(this.mainQueryParams)

  constructor(private http: HttpClient) { }

  getTeamStatYearly(teamId: Number, stat: String, fromYear: Number, toYear: Number) : Observable<SeasonAverageAttribute[]> {
    return this.http.get<SeasonAverageAttribute[]>(this.baseUrl + 'games/yearlyAverage/attribute/' + stat + '/team/'+ teamId +'/fromYear/' + fromYear + '/toYear/' + toYear)
  }

  updateQueryParams(newParams: QueryParams) {
    this.mainQueryParams = newParams
    this.mainQueryParams$?.next(newParams)
  }

  sendQueryParams() {
    this.mainQueryParams$?.next(this.mainQueryParams)
  }
}
