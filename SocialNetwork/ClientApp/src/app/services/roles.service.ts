import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Role } from '../models/role';
import { HttpClient } from '@angular/common/http';
import { UpdateUserRoles } from '../models/UpdateUserRoles';

@Injectable({
  providedIn: 'root'
})

export class RolesService {
  
  constructor(private http: HttpClient, @Inject('BASE_URL') private url: string) {

  }
  getRoles(): Observable<Role[]> {
    return this.http.get<Role[]>(this.url + 'api/roles');
  }

  getRolesByUserId(id: number): Observable<string[]> {
    return this.http.get<string[]>(this.url + 'api/roles/'+id);
  }

  updateUserRoles(id: number, roles: string[]): Observable<void> {
    var updateUserRoles = new UpdateUserRoles();
    updateUserRoles.RolesToAssign = roles;
    return this.http.put<void>(this.url + 'api/roles/' + id, updateUserRoles);
  }
  
}
