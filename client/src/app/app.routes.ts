import { Routes } from '@angular/router';
import { VisualizationComponent } from './Pages/visualization/visualization.component';
import { AboutComponent } from './Pages/about/about.component';
import { FormComponent } from './Pages/form/form.component';

export const routes: Routes = [
    { path: '', pathMatch: 'full', redirectTo: 'about' },
    { path: 'about', component: AboutComponent },
    { path: 'visualization', component: VisualizationComponent },
    { path: 'form', component: FormComponent}
];
