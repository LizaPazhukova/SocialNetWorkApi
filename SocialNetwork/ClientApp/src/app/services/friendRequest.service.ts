import { Injectable } from '@angular/core';
import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FriendRequest } from '../models/friend-request';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class FriendRequestService {
  public requests: FriendRequest[];
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  sendFriendRequest(id) {
    alert(id);
    return this.http.get(this.baseUrl + 'api/friendRequest/sendRequest/'+id).subscribe();
  }
  acceptRequest(id) {
    return this.http.get(this.baseUrl + 'api/friendRequest/acceptRequest/' + id);
  }
  getRequests(): Observable<FriendRequest[]> {
    return this.http.get<FriendRequest[]>(this.baseUrl + 'api/friendRequest/requests/');
  }
}

