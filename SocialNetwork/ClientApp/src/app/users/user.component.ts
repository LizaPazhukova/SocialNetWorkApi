import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';

import { FormModalComponent } from '../form-modal/form-modal.component';
import { FriendRequestService } from '../services/friendRequest.service';
import { User } from '../models/users';
import { UserService } from '../services/user.service';
import { searchUser, Gender } from '../models/searchUser';

@Component({
  selector: 'app-users',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  form: FormGroup;
  public users: User[];
  public searchUser: searchUser;
  private minAge: number;
  private maxAge: number;
  private gender: Gender;

  constructor(
    private FriendRequestService: FriendRequestService,
    private UserService: UserService,
    private modalService: NgbModal,
    private formBuilder: FormBuilder
  )
  {
    this.createForm();
  }
  ngOnInit() {
    this.UserService.getUsers(this.searchUser).subscribe(result => {
      this.users = result;
    }, error => console.error(error));
  }
  private createForm() {
    this.form = this.formBuilder.group({
      name: '',
      city: '',
      gender: this.gender,
      minAge: this.minAge,
      maxAge: this.maxAge,
    });
  }
  private search() {
    var user = new searchUser;
    user.name = this.form.value.name;
    user.city = this.form.value.city;
    user.gender = this.form.value.gender;
    user.minAge = this.form.value.minAge;
    user.maxAge = this.form.value.maxAge;

    this.UserService.getUsers(user).subscribe(result => {
      this.users = result;
    }, error => console.error(error));
    
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


