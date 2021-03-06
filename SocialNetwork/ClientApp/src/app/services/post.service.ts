import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Post } from '../models/post';
import { Observable } from 'rxjs';
import { Like } from '../models/like';
import { Comment } from '../models/comment';

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

  getPosts(UserId: number): Observable<Post[]> {
    return this.http.get<Post[]>(this.url + 'api/posts/'+UserId);
  }
  createPost(post: Post): Observable<Post> {
    return this.http.post<Post>(this.url + 'api/posts', post);
  }
  likePost(like: Like): Observable<Like> {
    return this.http.post<Like>(this.url + 'api/posts/like/', like);
  }
  createComment(comment: Comment): Observable<Comment> {
    return this.http.post<Comment>(this.url + 'api/posts/comment', comment);
  }
  deletePost(id: number) {
    return this.http.delete<Post>(this.url + 'api/posts/'+id);
  }
}
