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
const ng_bootstrap_1 = require("@ng-bootstrap/ng-bootstrap");
const core_1 = require("@angular/core");
const forms_1 = require("@angular/forms");
const message_1 = require("../models/message");
const message_service_1 = require("../services/message.service");
let FormModalComponent = class FormModalComponent {
    constructor(activeModal, formBuilder, messageService) {
        this.activeModal = activeModal;
        this.formBuilder = formBuilder;
        this.messageService = messageService;
        this.createForm();
    }
    createForm() {
        this.myForm = this.formBuilder.group({
            text: ''
        });
    }
    submitForm() {
        var message = new message_1.Message();
        message.toUserId = this.id;
        message.body = this.myForm.value.text;
        this.messageService.sendMessage(message).subscribe();
        this.activeModal.close(this.myForm.value);
    }
};
__decorate([
    core_1.Input(),
    __metadata("design:type", Number)
], FormModalComponent.prototype, "id", void 0);
FormModalComponent = __decorate([
    core_1.Component({
        selector: 'app-form-modal',
        templateUrl: './form-modal.component.html'
    }),
    __metadata("design:paramtypes", [ng_bootstrap_1.NgbActiveModal,
        forms_1.FormBuilder,
        message_service_1.MessageService])
], FormModalComponent);
exports.FormModalComponent = FormModalComponent;
//# sourceMappingURL=form-modal.component.js.map