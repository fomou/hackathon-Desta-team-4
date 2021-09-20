import { Component, OnInit, ViewChild, ElementRef, HostListener } from '@angular/core';
import { CommunicationService } from '../communication.service';


@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit {
 @ViewChild('newMessage') public message: ElementRef<HTMLInputElement>;
  user = {
    username: 'User',
    icon: 'non',
    messages: [],
  };

  bot = {
    username: 'Desta Bot',
    messages : [],
  };

  messages = [];

  date: string;
  constructor(private communicationService: CommunicationService) {
    this.communicationService.currentUser.asObservable().subscribe(user => {
      this.user = user;
    });
  }

  ngOnInit(): void {
    setTimeout(
      () => {
        this.botResponse('hey whats up?');
      }, 10000);
  }


  onSendMessage() {

    this.date = (new Date().toTimeString()).substr(0,5);
    this.messages.push({
      username: 'user',
      message: this.message.nativeElement.value
    });

    this.message.nativeElement.value = '';
    setTimeout(
      () => {
        this.botResponse('welcome to your platform');
      }, 10000);
  }

  private botResponse(res: string): void{
    this.date = ((new Date()).toTimeString()).substr(0,5);
    this.messages.push({
      username: 'bot',
      message:res
    });
  }

  @HostListener('keydown.enter', ['$event'])
  onEnter(event: KeyboardEvent) {
    event.preventDefault();
    this.onSendMessage();
  }

  getClass(message: any): string {
    return message.username === 'user' ? 'chat-message-right pb-4' : ' chat-message-left pb-4';
  }


}
