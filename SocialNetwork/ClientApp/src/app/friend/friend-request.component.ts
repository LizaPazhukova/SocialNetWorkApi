import { Component, OnInit } from '@angular/core';

import { FriendRequestService } from '../services/friendRequest.service';
//import { User } from '../models/users';
//import { UserService } from '../services/user.service';
import { FriendRequest } from '../models/friend-request';

@Component({
  selector: 'app-requests',
  templateUrl: './friend-request.component.html'
})
export class FriendRequestComponent implements OnInit {
  //public users: User[];
  public requests: FriendRequest[];
  constructor(private friendRequestService: FriendRequestService,
    //private UserService: UserService
  ) {

  }
  ngOnInit() {
    this.friendRequestService.getRequests().subscribe(result => {
      this.requests = result;
    }, error => console.error(error));;
  }
}
