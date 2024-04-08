import { Router } from '@angular/router';
import { Component } from '@angular/core';

@Component({
  selector: 'app-about',
  standalone: true,
  imports: [],
  templateUrl: './about.component.html',
  styleUrl: './about.component.css'
})
export class AboutComponent {
  constructor(private router: Router) {}

  navigateToQueryPage(): void {
    this.router.navigateByUrl('/form');
  }
}