import { Router } from '@angular/router';
import { Component } from '@angular/core';
import { User } from '../../Models/user';
import { QueryService } from '../../Services/query.service';

@Component({
  selector: 'app-about',
  standalone: true,
  imports: [],
  templateUrl: './about.component.html',
  styleUrl: './about.component.css'
})
export class AboutComponent{
  users: User[] = []
  numberOfTuples: number = 0;

  constructor(private router: Router, private queryService: QueryService) {}

  navigateToQueryPage(): void {
    this.router.navigateByUrl('/form');
  }
  
  getNumberOfTuples() {
    console.log('Getting tuple count')
    this.queryService.getNumberOfTuples().subscribe({
      next: res => {
        this.numberOfTuples = res[0].intAttribute
      },
      error: err => console.log(err)
    })
  }
}