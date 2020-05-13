import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../models/users';
import { Observable } from 'rxjs';
import { searchUser } from '../models/searchUser';


@Injectable({
  providedIn: 'root'
})
export class UserService {
  public users: User[];
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    
  }

  getUsers(searchUser: searchUser): Observable<User[]>{
    return this.http.post<User[]>(this.baseUrl + 'api/home/users', searchUser);
  }
  getCurrentUser(): Observable<User> {
    return this.http.get<User>(this.baseUrl + 'api/home/currentUser');
  }
}

  
