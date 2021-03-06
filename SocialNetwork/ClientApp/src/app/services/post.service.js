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
let PostService = class PostService {
    constructor(http, url) {
        this.http = http;
        this.url = url;
        this.httpOptions = {
            headers: new http_1.HttpHeaders({
                'Content-Type': 'application/json; charset=utf-8'
            })
        };
    }
    getPosts(UserId) {
        return this.http.get(this.url + 'api/posts/' + UserId);
    }
    createPost(post) {
        return this.http.post(this.url + 'api/posts', post);
    }
    likePost(like) {
        return this.http.post(this.url + 'api/posts/like/', like);
    }
    createComment(comment) {
        return this.http.post(this.url + 'api/posts/comment', comment);
    }
    deletePost(id) {
        return this.http.delete(this.url + 'api/posts/' + id);
    }
};
PostService = __decorate([
    core_1.Injectable({
        providedIn: 'root'
    }),
    __param(1, core_1.Inject('BASE_URL')),
    __metadata("design:paramtypes", [http_1.HttpClient, String])
], PostService);
exports.PostService = PostService;
//# sourceMappingURL=post.service.js.map