import { AfterViewInit, Component, ViewChild, OnInit } from '@angular/core';
import { FirebaseService } from './firebase.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  title = 'desta-Project';
  isSignIn = false;
  constructor(public firebaseService: FirebaseService) { }

  ngOnInit() {
    this.isSignIn = (localStorage.getItem('user') != null) ? true : false;

  }

  async onSignIn(email: string, password: string) {
    await this.firebaseService.signIn(email, password);
    this.isSignIn = this.firebaseService.isLoggedIn;
  }
  async onSignup(email: string, password: string) {
    await this.firebaseService.signUp(email, password);
    this.isSignIn = this.firebaseService.isLoggedIn;
  }

}
