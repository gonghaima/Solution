import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Movie } from '../view-models/Movie';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/delay';
import 'rxjs/add/operator/do';
import { StorageService } from './storage.service';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class AppDataService {
  apiRoot = `http://localhost:49795`;
  constructor(
    private httpClient: HttpClient,
    private storageService: StorageService
  ) {}
  public movies: Array<Movie> = [
    // tslint:disable-next-line:max-line-length
    {
      _movieId: 1,
      _title: 'The Frozen Ground',
      _genre: 'Thriller',
      _classification: 'M15+"',
      _releaseDate: 2013,
      _rating: 3,
      _cast: ['Alberto Bartolini', 'Dav_movieIde Cortesi', 'Darkwing']
    }
  ];

  createMovie(vm: Movie): Observable<any> {
    // return Observable.of({}).delay(2000).flatMap(x=>Observable.throw('Unable to create Movie'));
    let _movieId = 0;
    this.movies.forEach(c => {
      if (c._movieId >= _movieId) {
        _movieId = c._movieId + 1;
      }
    });
    vm._movieId = _movieId;
    this.movies.push(vm);
    return Observable.of(vm);
  }

  deleteMovie(_movieId: number): Observable<any> {
    return Observable.of({})
      .delay(2000)
      .do(e =>
        this.movies.splice(
          this.movies.findIndex(c => c._movieId === _movieId),
          1
        )
      );
  }

  getMovies() {
    const headers = new HttpHeaders().set('Access-Control-Allow-Origin', '*');
    return this.httpClient.get(`${this.apiRoot}/api/movies`, {headers});
  }

  getMovie(_movieId: number): Observable<Movie> {
    console.log('getMovie', this.movies.length);

    const movie = this.movies.find(c => c._movieId === _movieId);
    return Observable.of(movie);
  }

  updateMovie(updatedMovie: Movie): Observable<any> {
    // const movie = this.movies.find(c => c._movieId === updatedMovie._movieId);

    // const movie = this.storageService.movies.find(c => c._movieId === updatedMovie._movieId);
    // this.httpClient.put(`${this.apiRoot}/api/movies`, updatedMovie);
    // debugger;
    // Object.assign(movie, updatedMovie);
    // return Observable.of(movie).delay(2000);

    const headers = new HttpHeaders().set('Access-Control-Allow-Origin', '*');

    return this.httpClient.post(`${this.apiRoot}/api/movies`,
      updatedMovie);

    // const movie = this.storageService.movies.find(
    //   c => c._movieId === updatedMovie._movieId
    // );
    // Object.assign(movie, updatedMovie);
    // return Observable.of(movie).delay(2000);
  }
}
