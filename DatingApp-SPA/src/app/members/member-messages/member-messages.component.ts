import { Message } from './../../_models/message';
import { Component, OnInit, Input } from '@angular/core';
import { UserService } from 'src/app/_services/user.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-member-messages',
  templateUrl: './member-messages.component.html',
  styleUrls: ['./member-messages.component.css']
})
export class MemberMessagesComponent implements OnInit {
  @Input() recipientId: number;
  messages: Message[];

  constructor(
    private userService: UserService,
    private alertify: AlertifyService,
    private authService: AuthService
  ) { }

  ngOnInit() {
    this.loadMessages();
  }

  loadMessages() {
    this.userService.getMessageThread(this.authService.decodedToken.nameid, this.recipientId)
      .subscribe(messages => {
        this.messages = messages;
      }, error => {
        this.alertify.error(error);
      });
  }
}
