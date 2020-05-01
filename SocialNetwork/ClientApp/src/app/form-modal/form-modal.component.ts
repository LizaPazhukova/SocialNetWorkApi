import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Component, Output, EventEmitter, Input } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';

import { Message } from '../models/message';
import { MessageService } from '../services/message.service';

@Component({
  selector: 'app-form-modal',
  templateUrl: './form-modal.component.html'
})
export class FormModalComponent {
  @Input() id: number;
  myForm: FormGroup;
 
  

  constructor(
    public activeModal: NgbActiveModal,
    private formBuilder: FormBuilder,
    private messageService: MessageService
  )
  {
    this.createForm();
  }
  private createForm() {
    this.myForm = this.formBuilder.group({
      text: ''
    });
  }
  private submitForm() {
    var message = new Message();
    message.toUserId = this.id;
    message.body = this.myForm.value.text;

    this.messageService.sendMessage(message).subscribe();
    this.activeModal.close(this.myForm.value);
  }
}
