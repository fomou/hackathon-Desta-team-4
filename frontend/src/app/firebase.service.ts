import { Injectable } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/Auth';
@Injectable({
  providedIn: 'root'
})
export class FirebaseService {

  isLoggedIn = false;
  constructor(public authService: AngularFireAuth) { }

  async signIn(email: string, password: string) {
    await this.authService.signInWithEmailAndPassword(email, password).then((res) => {
      this.isLoggedIn = true;
      localStorage.setItem('user', JSON.stringify(res.user));
    })
  }

  async signUp(email: string, password: string) {
    await this.authService.createUserWithEmailAndPassword(email, password).then((res) => {
      this.isLoggedIn = true;
      localStorage.setItem('user', JSON.stringify(res.user));
    })
  }

  logout() {
    this.authService.signOut();
    localStorage.removeItem('user');
  }
}
