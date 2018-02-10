import { Routes } from '@angular/router';
import { MovieMainComponent } from './movie-main/movie-main.component';
import { MovieDetailComponent } from './movie-detail/movie-detail.component';


export const appRoutes: Routes = [
  { path: 'movies', component: MovieMainComponent },
  { path: 'movie-detail/:id/:operation', component: MovieDetailComponent },
  { path: '**', component: MovieMainComponent }
];
