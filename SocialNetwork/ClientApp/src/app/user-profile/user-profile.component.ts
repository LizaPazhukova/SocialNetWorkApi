import { Component, OnInit } from '@angular/core';
import { AuthorizeService} from 'src/api-authorization/authorize.service';
import { User } from 'src/app/models/users';
import { UserService } from 'src/app/services/user.service';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html'
})

export class UserProfileComponent implements OnInit {
  Name: Observable<string>;

  constructor(private authorizeService: AuthorizeService) {}
  ngOnInit() {
    this.Name = this.authorizeService.getUser().pipe(map(u => u && u.name));
  }
}
