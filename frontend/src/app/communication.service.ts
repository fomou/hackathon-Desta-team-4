import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';

const URL = 'https://evening-ocean-30323.herokuapp.com/https://destanationconnect.azurewebsites.net/';
//const URL = 'https://destanationconnect.azurewebsites.net/';

@Injectable({
  providedIn: 'root'
})
export class CommunicationService {

  isSignedIn= new BehaviorSubject<boolean>(false);
  currentUser = new BehaviorSubject<any>(undefined);
  constructor(private htpp: HttpClient) {
    this.currentUser = new BehaviorSubject<any>(undefined);
    this.isSignedIn = new BehaviorSubject<boolean>(false);
   }

  getAllUsers(): Observable<any>{
    return this.htpp.get(URL + 'api/tag');

  }

  login(user: any): Observable<any>{
    return this.htpp.post<any>(URL + 'api/account/login', user);
  }

  getCurrentUser(): any{
    return this.currentUser.getValue();
  }



}
