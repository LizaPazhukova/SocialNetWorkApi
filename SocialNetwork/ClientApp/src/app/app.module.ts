import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { Ng2SearchPipeModule } from 'ng2-search-filter';



import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { UserComponent } from './users/user.component';
import { PostComponent } from './posts/post.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { MessageComponent } from './message/message.component';
import { LoginComponent } from 'src/api-authorization/login/login.component';
import { FormModalComponent } from './form-modal/form-modal.component';
import { FriendRequestComponent } from './friend/friend-request.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    UserComponent,
    PostComponent,
    UserProfileComponent,
    MessageComponent,
    FormModalComponent,
    FriendRequestComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ApiAuthorizationModule,
    Ng2SearchPipeModule,
    NgbModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, canActivate: [AuthorizeGuard] },
      { path: 'app-home/:id', component: HomeComponent, canActivate: [AuthorizeGuard] },
      { path: 'login', component: LoginComponent },
      { path: 'users', component: UserComponent, canActivate: [AuthorizeGuard] },
      { path: 'post', component: PostComponent, canActivate: [AuthorizeGuard] },
      { path: 'messages', component: MessageComponent, canActivate: [AuthorizeGuard] },
      { path: 'friends', component: FriendRequestComponent, canActivate: [AuthorizeGuard] },
      { path: 'app-post/:id', component: PostComponent, canActivate: [AuthorizeGuard] }
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent],
  entryComponents: [
    FormModalComponent
  ]
})
export class AppModule { }
