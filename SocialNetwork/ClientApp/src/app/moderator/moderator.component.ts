import { Component, OnInit } from "@angular/core";
import { Message } from "../models/message";
import { MessageService } from "../services/message.service";

@Component({
  selector: 'app-moderator',
  templateUrl: './moderator.component.html',
  styleUrls: ['./moderator.component.css']
})
export class ModeratorComponent implements OnInit {
  public messages: Message[];
  public canEditMessage: boolean[] = [];

  constructor(private messageService: MessageService) { }

  ngOnInit() {
    this.getAllMessages();
  }

  updateMessage(id: number, text: string) {
    alert(id);
  }

  delete(id: number) {
    this.messageService.deleteMessage(id).subscribe(() => this.getAllMessages());
  }

  getAllMessages() {
    this.messageService.getAllMessages().subscribe(result => { this.messages = result; },
      error => {
        console.log(error);
      });
  }
}
