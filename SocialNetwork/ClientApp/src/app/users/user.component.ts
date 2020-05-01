import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { FormModalComponent } from '../form-modal/form-modal.component';
import { FriendRequestService } from '../services/friendRequest.service';
import { User } from '../models/users';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './user.component.html'
})
export class UserComponent implements OnInit {
  public users: User[];

  constructor(private FriendRequestService: FriendRequestService, private UserService: UserService, private modalService: NgbModal) {
    
  }
  ngOnInit() {
    this.UserService.getUsers().subscribe(result => {
      this.users = result;
    }, error => console.error(error));;
  }
  sendFriendRequest(id: number) {

    this.FriendRequestService.sendFriendRequest(id);
  
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


