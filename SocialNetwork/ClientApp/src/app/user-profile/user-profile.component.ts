import { Component, OnInit } from '@angular/core';
import { User } from '../models/users';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html'
})
export class UserProfileComponent implements OnInit {
  user: User;

  constructor(private userService: UserService) {}
  ngOnInit() {
    this.userService.getCurrentUser().subscribe(result => this.user = result);
  }
}
