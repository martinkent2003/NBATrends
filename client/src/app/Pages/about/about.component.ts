import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { QueryService } from '../../Services/query.service';
import { User } from '../../Models/user';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-about',
  standalone: true,
  imports: [],
  templateUrl: './about.component.html',
  styleUrl: './about.component.css'
})
export class AboutComponent implements OnInit{
  users: User[] = []

  constructor(private router: Router, private queryService: QueryService) {}

  ngOnInit(): void {
    this.queryService.getAllUsers().subscribe({
      next: res => {
        console.log(this.users.length);
        this.users = res;
      },
      error: err => console.log(err)
    })
  }

  navigateToQueryPage(): void {
    this.router.navigateByUrl('/form');
  }
}