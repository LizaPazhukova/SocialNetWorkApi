import { Component, OnInit } from '@angular/core';
import { FriendRequestService } from 'src/app/services/friendRequest.service';
import { User } from 'src/app/models/users';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './user.component.html'
})
export class UserComponent implements OnInit {
  public users: User[];

  constructor(private FriendRequestService: FriendRequestService, private UserService: UserService) {
    
  }
  ngOnInit() {
    this.UserService.getUsers().subscribe(result => {
      this.users = result;
    }, error => console.error(error));;
  }
  sendFriendRequest(id: number) {

    this.FriendRequestService.sendFriendRequest(id);
  
  }
}


