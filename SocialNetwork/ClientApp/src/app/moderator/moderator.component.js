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
let ModeratorComponent = class ModeratorComponent {
    constructor(messageService) {
        this.messageService = messageService;
        this.canEditMessage = [];
    }
    ngOnInit() {
        this.getAllMessages();
    }
    updateMessage(id, text) {
        let message = new message_1.Message();
        message.Id = id;
        message.body = text;
        this.messageService.updateMessage(message).subscribe(() => { this.getAllMessages(); this.canEditMessage = []; });
    }
    delete(id) {
        this.messageService.deleteMessage(id).subscribe(() => this.getAllMessages());
    }
    getAllMessages() {
        this.messageService.getAllMessages().subscribe(result => { this.messages = result; }, error => {
            console.log(error);
        });
    }
};
ModeratorComponent = __decorate([
    core_1.Component({
        selector: 'app-moderator',
        templateUrl: './moderator.component.html',
        styleUrls: ['./moderator.component.css']
    }),
    __metadata("design:paramtypes", [message_service_1.MessageService])
], ModeratorComponent);
exports.ModeratorComponent = ModeratorComponent;
//# sourceMappingURL=moderator.component.js.map