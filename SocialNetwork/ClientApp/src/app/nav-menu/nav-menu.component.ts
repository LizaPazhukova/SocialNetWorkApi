import { Component, OnInit } from '@angular/core';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { Observable } from 'rxjs';
import { UserService } from '../services/user.service';
import { User } from '../models/users';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit{
  isExpanded = false;
  public isAuthenticated: Observable<boolean>;

  constructor(private authorizeService: AuthorizeService, private userService: UserService) { }
  ngOnInit() {
    this.isAuthenticated = this.authorizeService.isAuthenticated();
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
