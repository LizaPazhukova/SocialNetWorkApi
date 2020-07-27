import { Component, OnInit } from '@angular/core';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { FriendRequestService } from '../services/friendRequest.service';
import { MessageService } from '../services/message.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit{
  isExpanded = false;
  public isAuthenticated: boolean;
  public activeRequestsCount: number;
  public unreadedMessagesCount: number;

  constructor(private authorizeService: AuthorizeService, private friendService: FriendRequestService, private messageService: MessageService) { }
  ngOnInit() {
    this.authorizeService.isAuthenticated().subscribe(result => {
      this.isAuthenticated = result;
      if (result) {
        this.friendService.getFriendRequestCount().subscribe(result => this.activeRequestsCount = result);
        this.messageService.countUnreadedMessages().subscribe(result => this.unreadedMessagesCount = result);
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
