import { Component, Inject} from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PostService } from 'src/app/services/post.service';
import { Post } from 'src/app/models/post';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html'
})


export class PostComponent {
  public posts: Post[] = [];
  text: string;

  constructor( private postService: PostService) {

  }
  
  ngOnInit() {
    this.postService.getPosts().subscribe(result => {
      this.posts = result;
    }, error => console.error(error));;
  }

  createPost() {
    
    this.postService.createPost(new Post(this.text)).subscribe(result => this.posts.push(result));
    
  }

}


