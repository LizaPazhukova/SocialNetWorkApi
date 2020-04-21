import { Component, Inject} from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PostService } from 'src/app/services/post.service';
import { UserService } from 'src/app/services/user.service';
import { User } from 'src/app/models/users';
import { Post } from 'src/app/models/post';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html'
})


export class PostComponent {
  public posts: Post[] = [];
  text: string;
  user: User;

  constructor( private postService: PostService, private userService: UserService) {

  }
  
  ngOnInit() {
    this.postService.getPosts().subscribe(result => {
      this.posts = result.sort(x => x.Date);
    }, error => console.error(error));;
    this.userService.getCurrentUser().subscribe(result => {
      this.user = result;
    }, error => console.error(error));;
  }

  createPost() {
    
    this.postService.createPost(new Post(this.text)).subscribe(result => this.posts.unshift(result));
    this.text = '';
  }

}


