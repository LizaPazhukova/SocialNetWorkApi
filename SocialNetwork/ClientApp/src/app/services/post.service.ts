import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Post } from '../models/post';
import { Observable } from 'rxjs';
import { Like } from '../models/like';


@Injectable({
  providedIn: 'root'
})

export class PostService {
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient, @Inject('BASE_URL') private url: string) {

  }

  getPosts(): Observable<Post[]> {
    return this.http.get<Post[]>(this.url + 'api/home/posts');
  }
  createPost(post: Post): Observable<Post> {
    return this.http.post<Post>(this.url + 'api/home/post/', post);
  }
  likePost(like: Like): Observable<Like> {
    return this.http.post<Like>(this.url + 'api/home/like/', like);
  }
}
