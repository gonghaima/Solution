import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';

import { AppDataService } from '../services/app-data.service';

import { FieldDefinition } from '../../fw/dynamic-forms/field-definition';
import { Movie } from '../view-models/Movie';
import { StorageService } from '../services/storage.service';
import { FormFieldDefinition } from './form-field-definition';

@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.css']
})
export class MovieDetailComponent implements OnInit {
  movie: Movie;
  movieDefinition: Array<FieldDefinition> = FormFieldDefinition;
  errorMessage: string;
  operation: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private dataService: AppDataService,
    private storageService: StorageService
  ) {}

  createMovie(movie: Movie) {
    movie._movieId = 0;
    this.errorMessage = null;
    this.dataService
      .createMovie(movie)
      .subscribe(
        c => this.router.navigate(['/movie-main']),
        err => (this.errorMessage = 'Error creating movie')
      );
  }

  ngOnInit() {
    this.operation = this.route.snapshot.params['operation'];

    if (this.operation === 'create') {
      // tslint:disable-next-line:max-line-length
      this.movie = {
        _movieId: 0,
        _cast: 13,
        _classification: 'PG',
        _genre: 'few',
        _rating: 18,
        _releaseDate: 219,
        _title: 'Social network'
      };
    } else {
      this.movie = this.storageService.getMovie(
        this.route.snapshot.params['id']
      );
    }
  }
  updateMovie(movie: Movie) {
    this.errorMessage = null;
    this.dataService.updateMovie(movie).subscribe(
      success => {
        this.handleSuccess(movie);
      },
      err => {
        this.errorMessage = 'Error updating movie';
      }
    );
  }

  handleSuccess(movie: Movie) {
    const movie_data = this.storageService.movies.find(
      g => g._movieId === movie._movieId
    );
    Object.assign(movie_data, movie);
    this.router.navigate(['/movie-main']);
  }

}
