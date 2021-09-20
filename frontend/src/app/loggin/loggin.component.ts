import { Component, ElementRef, HostListener, OnInit, ViewChild } from '@angular/core';
import { FirebaseService } from '../firebase.service';
import { Router } from '@angular/router';
import { CommunicationService } from '../communication.service';
@Component({
  selector: 'app-loggin',
  templateUrl: './loggin.component.html',
  styleUrls: ['./loggin.component.scss']
})
export class LogginComponent implements OnInit {

  user: any;

  @ViewChild('password') public password: ElementRef<HTMLInputElement>;
  @ViewChild('email') public email: ElementRef<HTMLInputElement>;
  constructor(private authService: FirebaseService, private router: Router, private communicationService:CommunicationService) { }

  ngOnInit(): void {
  }

  @HostListener('keydown.enter', ['$event'])
   onSignIn(){
    const user2 = {
      token: 'string',
      lang: 'string',
      data: {
        Username: 'destau1',
        Email: this.email.nativeElement.value,
        Password: this.password.nativeElement.value,
        AccessCode: 'string',
        RememberMe: 'true'
      },
      payLoad: 'string'
    };

    this.communicationService.login(user2).subscribe(user => {
      if (user.data === null) {
        window.alert('user not found');
        this.email.nativeElement.value = '';
        this.password.nativeElement.value = '';
        return;
      }
      this.user = user.data;
      this.communicationService.currentUser.next(user);
      this.communicationService.isSignedIn.next(true);
      this.router.navigate(['home']);
    });


  }



}
