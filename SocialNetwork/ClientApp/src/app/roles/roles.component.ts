import { Component, OnInit, Input } from '@angular/core';
import { Role } from '../models/role';
import { RolesService } from '../services/roles.service';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html'
})


export class RolesComponent implements OnInit {
  public roles: Role[] = [];
  public userRoles: string[] = [];
  public id: number;

  constructor(private rolesService: RolesService, private _route: ActivatedRoute) { }

  ngOnInit() {
    this.rolesService.getRoles().subscribe(result => this.roles = result);
    this._route.params.subscribe(params => {
      this.id = params['id'];
      this.getRolesByUserId(this.id);
    });    
  }

  getRolesByUserId(id: number) {
    this.rolesService.getRolesByUserId(id).subscribe(result => this.userRoles = result);
  }

  onSubmit(roleForm: NgForm) {
    console.log(roleForm);
    let selectedRoles: string[] = [];
    Object.keys(roleForm.controls).forEach(key => {
      if (roleForm.controls[key].value) {
        selectedRoles.push(key);
      }
    });

    this.rolesService.updateUserRoles(this.id, selectedRoles).subscribe(() => alert("Succesfully saved"));
  }

  isAnySelected(roleForm: NgForm) {
    return !Object.keys(roleForm.controls).some(key => roleForm.controls[key].value);
  }
}

