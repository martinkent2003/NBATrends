import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { User } from "../Models/user";

@Injectable({providedIn: 'root'})
export class QueryService {
  baseUrl = 'https://localhost:5001/api/'

  constructor(private http: HttpClient) { }

  getAllUsers() {
    return this.http.get<User[]>(this.baseUrl + 'users')
  }
}