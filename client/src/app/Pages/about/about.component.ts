import { Router } from '@angular/router';
import { Component } from '@angular/core';
import { User } from '../../Models/user';

@Component({
  selector: 'app-about',
  standalone: true,
  imports: [],
  templateUrl: './about.component.html',
  styleUrl: './about.component.css'
})
export class AboutComponent{
  users: User[] = []

  constructor(private router: Router) {}

  navigateToQueryPage(): void {
    this.router.navigateByUrl('/form');
  }
}