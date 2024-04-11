import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { User } from "../Models/user";

@Injectable({providedIn: 'root'})
export class QueryService {
  baseUrl = 'http://localhost:5000/api/'

  constructor(private http: HttpClient) { }

  getAllUsers() {
    return this.http.get<User[]>(this.baseUrl + 'users/')
  }
}