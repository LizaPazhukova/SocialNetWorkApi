import { Component, Inject} from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PostService } from '../services/post.service';
import { UserService } from '../services/user.service';
import { User } from '../models/users';
import { Post } from '../models/post';
import { Like } from '../models/like';

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
      this.posts = result.sort(x => x.date);
    }, error => console.error(error));
    this.userService.getCurrentUser().subscribe(result => {
      this.user = result;
    }, error => console.error(error));
    console.log(this.posts);
  }

  createPost() {
    
    this.postService.createPost(new Post(this.text)).subscribe(result => this.posts.unshift(result));
    this.text = '';
  }
  likePost(postId: number) {
    var like = new Like();
    like.postId = postId;

    this.postService.likePost(like).subscribe(() => this.postService.getPosts().subscribe(result => {
      this.posts = result.sort(x => x.date);
    }, error => console.error(error)));

  }

}


