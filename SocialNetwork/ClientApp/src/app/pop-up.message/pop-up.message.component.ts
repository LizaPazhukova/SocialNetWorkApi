import { Component, OnInit } from '@angular/core';
import { Message } from '../models/message';
import { MessageService } from '../services/message.service';

@Component({
  selector: 'app-pop-up-messages',
  templateUrl: './pop-up.message.component.html'
})
export class PopUpMessageComponent implements OnInit {
  public messages: Message[];

  constructor(private messageService: MessageService) {

  }
  ngOnInit() {
    this.messageService.getMessages().subscribe(result => {
      this.messages = result;
    }, error => console.error(error));;
  }

}
