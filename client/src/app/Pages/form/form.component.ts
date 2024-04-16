import { Component, OnInit } from '@angular/core';
import { ChartComponent } from '../visualization/chart/chart.component';
import { QueryService } from '../../Services/query.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [ChartComponent],
  templateUrl: './form.component.html',
  styleUrl: './form.component.css'
})
export class FormComponent implements OnInit{
  constructor(private queryService: QueryService, private router: Router) {}

  ngOnInit(): void {
    
  }

  onClick0() {
    this.queryService.mainQueryParams.queryOption = 0;
    this.router.navigateByUrl('/visualization');
  }

  onClick1() {
    this.queryService.mainQueryParams.queryOption = 1;
    this.router.navigateByUrl('/visualization');
  }

  onClick2() {
    this.queryService.mainQueryParams.queryOption = 2;
    this.router.navigateByUrl('/visualization');
  }

}
