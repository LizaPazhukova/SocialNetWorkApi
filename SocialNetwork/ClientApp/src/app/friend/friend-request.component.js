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
const friendRequest_service_1 = require("../services/friendRequest.service");
let FriendRequestComponent = class FriendRequestComponent {
    constructor(friendRequestService) {
        this.friendRequestService = friendRequestService;
    }
    ngOnInit() {
        this.friendRequestService.getRequests().subscribe(result => {
            this.requests = result;
        }, error => console.error(error));
        ;
    }
};
FriendRequestComponent = __decorate([
    core_1.Component({
        selector: 'app-requests',
        templateUrl: './friend-request.component.html'
    }),
    __metadata("design:paramtypes", [friendRequest_service_1.FriendRequestService])
], FriendRequestComponent);
exports.FriendRequestComponent = FriendRequestComponent;
//# sourceMappingURL=friend-request.component.js.map