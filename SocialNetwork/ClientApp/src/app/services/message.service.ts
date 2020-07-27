import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Message } from '../models/message';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class MessageService {
  public messages: Message[];
 
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

  }

  getMessages(): Observable<Message[]> {
    return this.http.get<Message[]>(this.baseUrl + 'api/message/messages');
  }
  sendMessage(message: Message): Observable<Message> {
    return this.http.post<Message>(this.baseUrl + 'api/message/send', message);
  }
  updateMessage(message: Message): Observable<Message> {
    return this.http.put<Message>(this.baseUrl + 'api/message/update', message);
  }
  getSelectedUserMessages(fromUserId: number, toUserId: number): Observable<Message[]> {
    return this.http.get<Message[]>(this.baseUrl + 'api/message/messagesWithOneUser/'+fromUserId+'/'+toUserId);
  }
  getAllMessages(): Observable<Message[]> {
    return this.http.get<Message[]>(this.baseUrl + 'api/message/allMessages');
  }
  deleteMessage(id: number): Observable<void> {
    return this.http.delete<void>(this.baseUrl + 'api/message/'+id);
  }
  countUnreadedMessages(): Observable<number> {
    return this.http.get<number>(this.baseUrl + 'api/message/count');
  }
  setUnreadedMessages(): Observable<void> {
    return this.http.get<void>(this.baseUrl + 'api/message/setUnreadedMessages');
  }
}
