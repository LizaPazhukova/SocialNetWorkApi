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
const message_1 = require("../models/message");
const message_service_1 = require("../services/message.service");
const user_service_1 = require("../services/user.service");
let MessageComponent = class MessageComponent {
    constructor(messageService, userService) {
        this.messageService = messageService;
        this.userService = userService;
    }
    ngOnInit() {
        this.messageService.getMessages().subscribe(result => {
            this.messages = result;
        }, error => console.error(error));
        this.userService.getCurrentUser().subscribe(result => { this.user = result; });
    }
    getSelectedUserMessages(fromUserId, toUserId) {
        this.interlocutorId = (toUserId == this.user.id) ? fromUserId : toUserId;
        this.messageService.getSelectedUserMessages(fromUserId, toUserId).subscribe(result => {
            this.selectedUserMessages = result;
        }, error => console.error(error));
    }
    submitForm(text) {
        var message = new message_1.Message();
        message.toUserId = this.interlocutorId;
        message.body = text;
        this.messageService.sendMessage(message).subscribe(() => this.getSelectedUserMessages(this.user.id, this.interlocutorId));
    }
};
MessageComponent = __decorate([
    core_1.Component({
        selector: 'app-messages',
        templateUrl: './message.component.html',
        styleUrls: ['./message.component.css']
    }),
    __metadata("design:paramtypes", [message_service_1.MessageService, user_service_1.UserService])
], MessageComponent);
exports.MessageComponent = MessageComponent;
//# sourceMappingURL=message.component.js.map