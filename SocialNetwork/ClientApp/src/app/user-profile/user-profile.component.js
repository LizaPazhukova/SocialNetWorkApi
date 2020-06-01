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
const users_1 = require("../models/users");
const user_service_1 = require("../services/user.service");
const router_1 = require("@angular/router");
let UserProfileComponent = class UserProfileComponent {
    constructor(userService, route) {
        this.userService = userService;
        this.route = route;
        this.gender = users_1.Gender;
    }
    ngOnInit() {
        this.route.params.subscribe(params => {
            this.id = params['id'];
        });
        if (this.id == undefined) {
            this.userService.getCurrentUser().subscribe(result => this.user = result);
        }
        else {
            this.userService.getUser(this.id).subscribe(result => {
                this.user = result;
            }, error => console.error(error));
        }
        //this.userService.getUser(this.id != undefined ? this.id : this.user.id).subscribe(result => this.user = result);
        //this.userService.getCurrentUser().subscribe(result => {
        //  this.user = result;
        //  if (this.id != this.user.id) {
        //  this.userService.getUser(this.id != undefined ? this.id : this.user.id).subscribe(result => {
        //    this.user = result;
        //  }, error => console.error(error));
        //}
        //this.userService.getCurrentUser().subscribe(result => {
        //  this.user = result;
        //  this.userService.getUser(this.id != undefined ? this.id : this.user.id).subscribe(result => {
        //    this.user = result;
        //  }, error => console.error(error));
        //});
    }
};
UserProfileComponent = __decorate([
    core_1.Component({
        selector: 'app-user-profile',
        templateUrl: './user-profile.component.html'
    }),
    __metadata("design:paramtypes", [user_service_1.UserService, router_1.ActivatedRoute])
], UserProfileComponent);
exports.UserProfileComponent = UserProfileComponent;
//# sourceMappingURL=user-profile.component.js.map