import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FriendRequestService } from 'src/app/services/friendRequest.service';
import { User } from 'src/app/models/users';

@Component({
  selector: 'app-users',
  templateUrl: './user.component.html'
})
export class UserComponent {
  public users: User[];

  constructor(private FriendRequestService: FriendRequestService, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<User[]>(baseUrl + 'api/home/users').subscribe(result => {
      this.users = result;
    }, error => console.error(error));
  }
  sendFriendRequest(id: number) {

    this.FriendRequestService.sendFriendRequest(id);
  
  }
}


