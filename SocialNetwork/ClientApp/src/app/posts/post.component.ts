import { Component, Inject, OnInit} from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PostService } from '../services/post.service';
import { UserService } from '../services/user.service';
import { User } from '../models/users';
import { Post } from '../models/post';
import { Like } from '../models/like';
import { Comment} from '../models/comment';
import { ActivatedRoute } from '@angular/router'

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html'
})


export class PostComponent implements OnInit {
  public posts: Post[] = [];
  text: string;
  public user: User;
  public isCollapsed : boolean[] = [];
  id: number;

  constructor(private postService: PostService, private userService: UserService, private route: ActivatedRoute) {}
  
  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });
    this.userService.getCurrentUser().subscribe(result => {
      this.user = result;
      this.postService.getPosts(this.id != undefined ? this.id : this.user.id).subscribe(result => {
        this.posts = result.sort(x => x.date);
      }, error => console.error(error));
    });
  }
  createPost() {
    // this.postService.createPost(new Post(this.text)).subscribe(result => this.posts.unshift(result));
    this.postService.createPost(new Post(this.text)).subscribe(() => this.postService.getPosts(this.id != undefined ? this.id : this.user.id).subscribe(result => {
      this.posts = result.sort(x => x.date);
    }, error => console.error(error)));
    this.text = '';
    //var post = new Post(this.text);
  }
  likePost(postId: number) {
    var like = new Like();
    like.postId = postId;
    this.postService.likePost(like).subscribe(() => this.postService.getPosts(this.id != undefined ? this.id : this.user.id).subscribe(result => {
      this.posts = result.sort(x => x.date);
    }, error => console.error(error)));

  }
  createComment(postId: number, text: string) {
    var comment = new Comment();
    comment.postId = postId;
    comment.text = text;
    this.postService.createComment(comment).subscribe(() => this.postService.getPosts(this.id != undefined ? this.id : this.user.id).subscribe(result => {
      this.posts = result.sort(x => x.date);
    }, error => console.error(error)));
  }
  deletePost(id: number) {
    this.postService.deletePost(id).subscribe(() => this.postService.getPosts(this.id != undefined ? this.id : this.user.id).subscribe(result => {
      this.posts = result.sort(x => x.date);
    }, error => console.error(error)));
  }
}


