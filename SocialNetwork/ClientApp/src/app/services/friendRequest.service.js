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
const core_2 = require("@angular/core");
const http_1 = require("@angular/common/http");
let FriendRequestService = class FriendRequestService {
    constructor(http, baseUrl) {
        this.http = http;
        this.baseUrl = baseUrl;
        this.httpOptions = {
            headers: new http_1.HttpHeaders({
                'Content-Type': 'application/json; charset=utf-8'
            })
        };
    }
    sendFriendRequest(id) {
        return this.http.get(this.baseUrl + 'api/friendRequest/sendRequest/' + id).subscribe();
    }
    acceptRequest(id) {
        return this.http.get(this.baseUrl + 'api/friendRequest/acceptRequest/' + id);
    }
    getRequests() {
        return this.http.get(this.baseUrl + 'api/friendRequest/requests/');
    }
    rejectRequest(id) {
        return this.http.get(this.baseUrl + 'api/friendRequest/rejectRequest/' + id);
    }
    getFriends() {
        return this.http.get(this.baseUrl + 'api/friendRequest/friends/');
    }
    getFriendRequestCount() {
        return this.http.get(this.baseUrl + 'api/friendRequest/count');
    }
};
FriendRequestService = __decorate([
    core_1.Injectable({
        providedIn: 'root',
    }),
    __param(1, core_2.Inject('BASE_URL')),
    __metadata("design:paramtypes", [http_1.HttpClient, String])
], FriendRequestService);
exports.FriendRequestService = FriendRequestService;
//# sourceMappingURL=friendRequest.service.js.map