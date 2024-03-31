import { Routes } from '@angular/router';
import { VisualizationComponent } from './Pages/visualization/visualization.component';
import { AboutComponent } from './Pages/about/about.component';

export const routes: Routes = [
    { path: '', component: VisualizationComponent },
    { path: 'about', component: AboutComponent },
];
