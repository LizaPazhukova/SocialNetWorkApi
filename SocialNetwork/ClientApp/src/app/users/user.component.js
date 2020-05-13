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
const ng_bootstrap_1 = require("@ng-bootstrap/ng-bootstrap");
const forms_1 = require("@angular/forms");
const form_modal_component_1 = require("../form-modal/form-modal.component");
const friendRequest_service_1 = require("../services/friendRequest.service");
const user_service_1 = require("../services/user.service");
const searchUser_1 = require("../models/searchUser");
let UserComponent = class UserComponent {
    constructor(FriendRequestService, UserService, modalService, formBuilder) {
        this.FriendRequestService = FriendRequestService;
        this.UserService = UserService;
        this.modalService = modalService;
        this.formBuilder = formBuilder;
        this.createForm();
    }
    ngOnInit() {
        this.UserService.getUsers(this.searchUser).subscribe(result => {
            this.users = result;
        }, error => console.error(error));
    }
    createForm() {
        this.form = this.formBuilder.group({
            name: '',
            city: '',
            gender: this.gender,
            minAge: this.minAge,
            maxAge: this.maxAge,
        });
    }
    search() {
        var user = new searchUser_1.searchUser;
        user.name = this.form.value.name;
        user.city = this.form.value.city;
        user.gender = this.form.value.gender;
        user.minAge = this.form.value.minAge;
        user.maxAge = this.form.value.maxAge;
        this.UserService.getUsers(user).subscribe(result => {
            this.users = result;
        }, error => console.error(error));
    }
    sendFriendRequest(id) {
        this.FriendRequestService.sendFriendRequest(id);
    }
    openFormModal(id) {
        const modalRef = this.modalService.open(form_modal_component_1.FormModalComponent);
        modalRef.componentInstance.id = id;
        modalRef.result.then((result) => {
            console.log(result);
        }).catch((error) => {
            console.log(error);
        });
    }
};
UserComponent = __decorate([
    core_1.Component({
        selector: 'app-users',
        templateUrl: './user.component.html',
        styleUrls: ['./user.component.css']
    }),
    __metadata("design:paramtypes", [friendRequest_service_1.FriendRequestService,
        user_service_1.UserService,
        ng_bootstrap_1.NgbModal,
        forms_1.FormBuilder])
], UserComponent);
exports.UserComponent = UserComponent;
//# sourceMappingURL=user.component.js.map