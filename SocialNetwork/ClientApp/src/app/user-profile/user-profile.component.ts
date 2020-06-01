import { Component, OnInit } from '@angular/core';
import { User, Gender } from '../models/users';
import { UserService } from '../services/user.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html'
})
export class UserProfileComponent implements OnInit {
  user: User;
  public gender: typeof Gender = Gender;
  id: number;

  constructor(private userService: UserService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });

    if (this.id == undefined) {
      this.userService.getCurrentUser().subscribe(result => this.user = result)
    }
    else {
      this.userService.getUser(this.id).subscribe(result => {
          this.user = result;
      }, error => console.error(error));
    }
  }
}
