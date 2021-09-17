import { Component, HostListener, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FirebaseService } from '../firebase.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  showStatement = false;
  constructor(private route: Router, private firebaseService: FirebaseService) { }

  ngOnInit(): void {
  }

  @HostListener('keyboad.enter', ['$event'])
  onSignup(email: string, password: string, confirmpas): void{
    if (password !== confirmpas) {
      window.alert('password dont mtche');
    } else {
      this.firebaseService.signUp(email, password);
      this.route.navigate(['home']);
    }

  }



}
