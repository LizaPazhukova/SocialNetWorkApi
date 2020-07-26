import { Component, OnInit } from '@angular/core';
import { AuthorizeService } from '../authorize.service';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { User } from 'src/app/models/users';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login-menu',
  templateUrl: './login-menu.component.html',
  styleUrls: ['./login-menu.component.css']
})
export class LoginMenuComponent implements OnInit {
  public isAuthenticated : boolean = true;
  public userName: Observable<string>;
  public user: User;
  public isModerator: boolean;

  constructor(private authorizeService: AuthorizeService,
    private userService: UserService) { }

  ngOnInit() {
    this.authorizeService.isAuthenticated().subscribe(val => {
      this.isAuthenticated = val;
      if (val) {
        this.userService.getCurrentUser().subscribe(result => {
          this.user = result;
          this.isModerator = this.user && this.user.roles && this.user.roles.includes("Moderator");
        });
      }
    });
    this.userName = this.authorizeService.getUser().pipe(map(u => u && u.name));
  }
}
