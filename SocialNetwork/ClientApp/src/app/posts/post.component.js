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
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const post_service_1 = require("../services/post.service");
const user_service_1 = require("../services/user.service");
const post_1 = require("../models/post");
const like_1 = require("../models/like");
const comment_1 = require("../models/comment");
let PostComponent = class PostComponent {
    constructor(postService, userService) {
        this.postService = postService;
        this.userService = userService;
        this.posts = [];
        this.isCollapsed = [];
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
        this.postService.createPost(new post_1.Post(this.text)).subscribe(result => this.posts.unshift(result));
        this.text = '';
    }
    likePost(postId) {
        var like = new like_1.Like();
        like.postId = postId;
        this.postService.likePost(like).subscribe(() => this.postService.getPosts().subscribe(result => {
            this.posts = result.sort(x => x.date);
        }, error => console.error(error)));
    }
    createComment(postId, text) {
        var comment = new comment_1.Comment();
        comment.postId = postId;
        comment.text = text;
        this.postService.createComment(comment).subscribe();
    }
};
PostComponent = __decorate([
    core_1.Component({
        selector: 'app-post',
        templateUrl: './post.component.html'
    }),
    __metadata("design:paramtypes", [post_service_1.PostService, user_service_1.UserService])
], PostComponent);
exports.PostComponent = PostComponent;
//# sourceMappingURL=post.component.js.map