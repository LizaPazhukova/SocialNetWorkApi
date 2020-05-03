import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { FriendRequestService } from '../services/friendRequest.service';
import { User } from '../models/users';
//import { UserService } from '../services/user.service';
import { FriendRequest } from '../models/friend-request';
import { FormModalComponent } from '../form-modal/form-modal.component';


@Component({
  selector: 'app-requests',
  templateUrl: './friend-request.component.html',
  styleUrls: ['./friend-request.component.css']
})
export class FriendRequestComponent implements OnInit {
  public friends: User[];
  public requests: FriendRequest[];
  constructor(private friendRequestService: FriendRequestService,
    private modalService: NgbModal
  ) {

  }
  ngOnInit() {
    this.getRequests();

    this.friendRequestService.getFriends().subscribe(result => {
      this.friends = result;
    }, error => console.error(error));
  }
  getRequests() {
    this.friendRequestService.getRequests().subscribe(result => {
      this.requests = result;
    }, error => console.error(error));
  }
  acceptRequest(id: number) {
    this.friendRequestService.acceptRequest(id).subscribe(() => this.getRequests());
  }
  rejectRequest(id: number) {
    this.friendRequestService.rejectRequest(id).subscribe(() => this.getRequests());
  }
  openFormModal(id: number) {
    const modalRef = this.modalService.open(FormModalComponent);
    modalRef.componentInstance.id = id;

    modalRef.result.then((result) => {
      console.log(result);
    }).catch((error) => {
      console.log(error);
    });
  }
}
