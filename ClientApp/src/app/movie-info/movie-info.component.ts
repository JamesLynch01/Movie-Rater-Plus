import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-movie-info',
  templateUrl: './movie-info.component.html',
  styleUrls: ['./movie-info.component.css']
})
export class MovieInfoComponent implements OnInit {

  public movies: Movie[];
  public newMovie: Movie = { title:'', director:'', mainCatergory:'', userRating: undefined }

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  async ngOnInit() {
      this.movies = await this.http.get<Movie[]>(this.baseUrl + 'movieinfo').toPromise();
  }

  async save() {
    await this.http.post<Movie[]>(this.baseUrl + 'movieinfo', this.newMovie).toPromise();
    this.newMovie = { title: '', director: '', mainCatergory: '', userRating: undefined};
    this.movies = await this.http.get<Movie[]>(this.baseUrl + 'movieinfo').toPromise();
  }

}

interface Movie {
  title: string;
  director: string;
  mainCatergory: string;
  userRating: number;
}
