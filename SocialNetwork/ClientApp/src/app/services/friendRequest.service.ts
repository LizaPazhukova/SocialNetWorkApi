import { Injectable } from '@angular/core';
import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class FriendRequestService {

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
}

