import { Component, OnInit, Input } from '@angular/core';
import { Message } from '../models/message';
import { MessageService } from '../services/message.service';
import { User } from '../models/users';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-messages',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.css']
})
export class MessageComponent implements OnInit {
  public messages: Message[];
  public selectedUserMessages: Message[];
  public user: User;
  public interlocutorId: number;

  constructor(private messageService: MessageService, private userService: UserService) {

  }
  ngOnInit() {
    this.messageService.getMessages().subscribe(result => {
      this.messages = result;
    }, error => console.error(error));

    this.userService.getCurrentUser().subscribe(result => { this.user = result});
  }
  getSelectedUserMessages(fromUserId: number, toUserId: number) {
    this.interlocutorId = (toUserId == this.user.id) ? fromUserId : toUserId;

    this.messageService.getSelectedUserMessages(fromUserId, toUserId).subscribe(result => {
      this.selectedUserMessages = result;
    }, error => console.error(error));
  }
  submitForm(text: string) {
    var message = new Message();
    message.toUserId = this.interlocutorId;
    message.body = text;

    this.messageService.sendMessage(message).subscribe(() => this.getSelectedUserMessages(this.user.id, this.interlocutorId));
    
  }
  
}
