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

  constructor(private messageService: MessageService) { }

  ngOnInit() {
    this.messageService.getAllMessages().subscribe(result => { this.messages = result; console.log(result) },
      error => {
        console.log(error);
    });
  }
}
