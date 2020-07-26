import { Component, OnInit } from '@angular/core';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { FriendRequestService } from '../services/friendRequest.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit{
  isExpanded = false;
  public isAuthenticated: boolean;
  public activeRequestsCount: number;

  constructor(private authorizeService: AuthorizeService, private friendService: FriendRequestService) { }
  ngOnInit() {
    this.authorizeService.isAuthenticated().subscribe(result => {
      this.isAuthenticated = result;
      if (result) {
        this.friendService.getFriendRequestCount().subscribe(result => this.activeRequestsCount = result);
      }
    });
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
