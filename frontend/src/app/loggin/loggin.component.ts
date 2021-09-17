import { Component, ElementRef, HostListener, OnInit, ViewChild } from '@angular/core';
import { FirebaseService } from '../firebase.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-loggin',
  templateUrl: './loggin.component.html',
  styleUrls: ['./loggin.component.scss']
})
export class LogginComponent implements OnInit {

  @ViewChild('password') public password: ElementRef<HTMLInputElement>;
  @ViewChild('email') public email: ElementRef<HTMLInputElement>;
  constructor(private authService: FirebaseService, private router: Router) { }

  ngOnInit(): void {
  }

  @HostListener('keydown.enter', ['$event'])
 async onSignIn(): Promise<void>{
   await this.authService.signIn(this.email.nativeElement.value, this.password.nativeElement.value).then(() => {

     if (this.authService.isLoggedIn) {
       this.router.navigate(['home']);
     }
   });
  }



}
