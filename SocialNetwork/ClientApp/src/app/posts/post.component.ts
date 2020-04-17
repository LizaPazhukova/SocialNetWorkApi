import { Component, Inject} from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html'
})
export class PostComponent {

  constructor(private http: HttpClient, @Inject('BASE_URL') private url: string) {

  }

  createPost(form: NgForm) {

    return this.http.post(this.url, form.value);
  }

}

export class Post {
  constructor(public text: string) { }
}
