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
let MessageService = class MessageService {
    constructor(http, baseUrl) {
        this.http = http;
        this.baseUrl = baseUrl;
        this.httpOptions = {
            headers: new http_1.HttpHeaders({
                'Content-Type': 'application/json; charset=utf-8'
            })
        };
    }
    getMessages() {
        return this.http.get(this.baseUrl + 'api/message/messages');
    }
    sendMessage(message) {
        return this.http.post(this.baseUrl + 'api/message/send', message);
    }
    updateMessage(message) {
        return this.http.put(this.baseUrl + 'api/message/update', message);
    }
    getSelectedUserMessages(fromUserId, toUserId) {
        return this.http.get(this.baseUrl + 'api/message/messagesWithOneUser/' + fromUserId + '/' + toUserId);
    }
    getAllMessages() {
        return this.http.get(this.baseUrl + 'api/message/allMessages');
    }
    deleteMessage(id) {
        return this.http.delete(this.baseUrl + 'api/message/' + id);
    }
    countUnreadedMessages() {
        return this.http.get(this.baseUrl + 'api/message/count');
    }
    setUnreadedMessages() {
        return this.http.get(this.baseUrl + 'api/message/setUnreadedMessages');
    }
};
MessageService = __decorate([
    core_1.Injectable({
        providedIn: 'root'
    }),
    __param(1, core_1.Inject('BASE_URL')),
    __metadata("design:paramtypes", [http_1.HttpClient, String])
], MessageService);
exports.MessageService = MessageService;
//# sourceMappingURL=message.service.js.map