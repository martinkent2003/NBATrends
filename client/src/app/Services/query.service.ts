import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { User } from "../Models/user";
import { LineData } from "../Models/dataPoint";

@Injectable({providedIn: 'root'})
export class QueryService {
  baseUrl = 'https://localhost:5001/api/'

  constructor(private http: HttpClient) { }

  getAllUsers() {
    return this.http.get<User[]>(this.baseUrl + 'users')
  }

  getTeamStatYearly(teamId: Number, stat: String, fromYear: Number, toYear: Number) : LineData {
    var teamLineData: LineData = {
      type: "line",
      showInLegend: true,
      name: teamId == 1 ? "Miami Heat" : teamId == 2 ? "Dallas Mavericks" : "Boston Celtics",
      dataPoints: [
        { x: 2010, y: Math.floor(Math.random() * 50 + 50), label: "2010" },
				{ x: 2011, y: Math.floor(Math.random() * 50 + 50), label: "2011" },
				{ x: 2012, y: Math.floor(Math.random() * 50 + 50), label: "2012" },
				{ x: 2013, y: Math.floor(Math.random() * 50 + 50), label: "2013" },
				{ x: 2014, y: Math.floor(Math.random() * 50 + 50), label: "2014" },
				{ x: 2015, y: Math.floor(Math.random() * 50 + 50), label: "2015" },
				{ x: 2016, y: Math.floor(Math.random() * 50 + 50), label: "2016" },
				{ x: 2017, y: Math.floor(Math.random() * 50 + 50), label: "2017" },
				{ x: 2018, y: Math.floor(Math.random() * 50 + 50), label: "2018" },
				{ x: 2019, y: Math.floor(Math.random() * 50 + 50), label: "2019" },
				{ x: 2020, y: Math.floor(Math.random() * 50 + 50), label: "2020" },
				{ x: 2021, y: Math.floor(Math.random() * 50 + 50), label: "2021" }
      ]
    }
    return teamLineData;
  }
}
