import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Movie } from '../view-models/Movie';
import { AppDataService } from '../services/app-data.service';
import { StorageService } from '../services/storage.service';

@Component({
  selector: 'app-movie-main',
  templateUrl: './movie-main.component.html',
  styleUrls: ['./movie-main.component.css']
})
export class MovieMainComponent {
  movies: Array<Movie>;
  deleteError: string;
  deleteId: number;
  isDeleting = false;

  constructor(
    private dataService: AppDataService,
    private storageService: StorageService,
    private router: Router
  ) {
    (storageService.movies.length === 0) ? this.initializeData() : this.movies = storageService.movies;
  }

  initializeData() {
    this.dataService.getMovies().subscribe(dd => {
      this.storageService.movies = dd as Movie[];
      this.movies = this.storageService.movies;
    });
  }

  cancelDelete() {
    this.isDeleting = false;
    this.deleteId = null;
  }

  createMovie() {
    this.router.navigate(['/movie-detail', 0, 'create']);
  }

  deleteMovie(id: number) {
    this.isDeleting = true;
    this.dataService.deleteMovie(id).subscribe(
      c => this.cancelDelete(),
      err => {
        this.deleteError = err;
        this.isDeleting = false;
      }
    );
  }

  deleteMovieQuestion(id: number) {
    this.deleteError = null;
    this.deleteId = id;
  }

  editMovie(id: number) {
    this.router.navigate(['/movie-detail', id, 'edit']);
  }

  showMovieDetail(id: number) {
    this.router.navigate(['/movie-detail', id, 'details']);
  }
}
