import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const URL = 'localhost:3000';
@Injectable({
  providedIn: 'root'
})
export class CommunicationService {

  constructor(private htpp: HttpClient) { }

  getAllUsers(): Observable<any>{
    return this.htpp.get(URL + '/uses');

  }

  login(user: any): Observable<any>{
    return this.htpp.post(URL + 'api/Account/Login', user );
  }
}
