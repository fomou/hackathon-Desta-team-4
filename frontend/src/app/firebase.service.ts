import { Injectable } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/Auth';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { User } from './interface/user';
@Injectable({
  providedIn: 'root'
})
export class FirebaseService {
  subject = new BehaviorSubject<boolean>(false);
  isSignin = this.subject.asObservable();
  isLoggedIn = false;
  userName: Observable<User>;
  constructor(public authService: AngularFireAuth) {

   }

  async signIn(email: string, password: string) {
    await this.authService.signInWithEmailAndPassword(email, password).then((res) => {
      this.isLoggedIn = true;
      //localStorage.setItem(res.user.email, JSON.stringify(res.user));
      this.subject.next(true);
      console.log('sign in');
    }).catch(err => {
      console.log(err);
    });
  }

  async signUp(email: string, password: string) {
    await this.authService.createUserWithEmailAndPassword(email, password).then((res) => {
      this.isLoggedIn = true;
      //localStorage.setItem('user', JSON.stringify(res.user));
      this.subject.next(true);

    }).catch(err => {
      console.log(err);
      this.subject.next(true);
    });
  }

   async logout() {
     await this.authService.signOut().then(() => {
       localStorage.removeItem('user');
       this.isSignin = of(false);
       console.log(this.isSignin);
       this.subject.next(false);
     }).catch(err => {
       console.log(err);
     });

  }
}
