import { AfterViewInit, Component, ViewChild, OnInit } from '@angular/core';
import { FirebaseService } from './firebase.service';
import { Observable,BehaviorSubject } from 'rxjs';
import { logging } from 'protractor';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  title = 'desta-Project';
  login: Observable<boolean>;
  isSignIn = false;
  constructor(private firebaseService: FirebaseService) {
    this.login = this.firebaseService.isSignin;
    this.firebaseService.subject.asObservable().subscribe((signedIn: boolean) => {
      this.isSignIn = signedIn;
      console.log(this.isSignIn);
    });
   }

  ngOnInit() {


  }

 async onLogout(): Promise<void>{
   await this.firebaseService.logout().then(() => {
     this.isSignIn = this.firebaseService.subject.getValue();
    });
  }

}
