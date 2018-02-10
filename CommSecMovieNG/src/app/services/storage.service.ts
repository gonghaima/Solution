import { Injectable } from '@angular/core';
import { Movie } from '../view-models/Movie';


@Injectable()
export class StorageService {
  constructor() {}
  public movies: Array<Movie> = [];

  getMovie(_movieId): Movie {
      const movie = this.movies.find(c => c._movieId.toString() === _movieId);
      return movie;
  }
}
