"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const http_1 = require("@angular/common/http");
class Post {
    constructor(text) {
        this.text = text;
    }
}
exports.Post = Post;
let PostComponent = class PostComponent {
    constructor(http, url) {
        this.http = http;
        this.url = url;
        this.posts = [];
    }
    //getPosts(): Observable<Post[]> {
    //  return this.http.get<Post[]>(this.url + 'api/home/posts');
    ngOnInit() {
        this.http.get(this.url + 'api/home/posts').subscribe(result => {
            this.posts = result;
        }, error => console.error(error));
        ;
    }
    createPost() {
        //this.posts.push(new Post(this.text));
        // alert(form.value.text);
        // this.posts.push(this.http.post(this.url, form.value.text));
        this.http.post(this.url + 'api/home/post/', new Post(this.text)).subscribe(result => this.posts.push(result));
    }
};
PostComponent = __decorate([
    core_1.Component({
        selector: 'app-post',
        templateUrl: './post.component.html'
    }),
    __param(1, core_1.Inject('BASE_URL')),
    __metadata("design:paramtypes", [http_1.HttpClient, String])
], PostComponent);
exports.PostComponent = PostComponent;
//# sourceMappingURL=post.component.js.map