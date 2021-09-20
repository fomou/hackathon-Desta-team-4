import { Component, HostListener, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Router } from '@angular/router';
import { stringify } from 'querystring';
import { FirebaseService } from '../firebase.service';
import { User } from '../interface/user';
@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  user: User;
  showStatement = false;
  moveToQuestion = false;
  moveToBusiness = false;
  moveToTags = false;
  userinfo = true;
  section: number;
  header = 'Create an account';

  @ViewChild('name') public username: ElementRef<HTMLInputElement>;
  @ViewChild('password') public password: ElementRef<HTMLInputElement>;
  @ViewChild('email') public email: ElementRef<HTMLInputElement>;
  @ViewChild('businessname') public businessname: ElementRef<HTMLInputElement>;
  @ViewChild('repeatPW') public repeatPassword: ElementRef<HTMLInputElement>;
  @ViewChild('businessadress') public businessadress: ElementRef<HTMLInputElement>;
  @ViewChild('accesscode') public accesscode: ElementRef<HTMLInputElement>;
  @ViewChild('site') public site: ElementRef<HTMLInputElement>;
  constructor(private route: Router, private firebaseService: FirebaseService) { }

  ngOnInit(): void {
  }

  @HostListener('keyboad.enter', ['$event'])
  async onSignup(): Promise<void>{
    await this.firebaseService.signUp(this.user.email, this.user.password);
    console.log(this.user);
    this.route.navigate(['home']);
  }

  setUserIds(email: string, password: string, confirmpas: string, name: string) {
    if (password !== confirmpas) {
      window.alert('password dont match');
      return;
    } else {
      console.log(this.user)
      this.user = {
        name: name,
        email: email,
        password: password,
        confirmpasswor: confirmpas
      }
      this.moveToQuestion = true;
    }
  }
  setBusinessesIds(name: string, adress: string, accesscode: string, site: string): void{
    if (name === '') {
      window.alert('you didn\'t');
    }
    if (accesscode === '') {
      window.alert('you need to have an access code ');
    }

    const user = {
      name: this.user.name,
      email: this.user.email,
      password: this.user.password,
      confirmpasswor: this.user.confirmpasswor,
      accesscode: accesscode,
      businessadress: adress,
      businessname: name,
      businesswebsite: site
    } as User;

    this.user = user;
    console.log(this.user);

  }

  updateView(): void {
    if (this.userinfo) {
      this.section = 1;
      this.moveToQuestion = true;
      this.moveToBusiness = false;
      this.moveToTags = false;
      this.userinfo = false;
      this.header = 'register your business';

      this.setUserIds(this.email.nativeElement.value, this.password.nativeElement.value,
        this.repeatPassword.nativeElement.value, this.username.nativeElement.value);
      console.log(this.user);
    }

    else if (this.moveToQuestion) {
      this.section = 2;
      this.moveToQuestion = false;
      this.moveToBusiness = true;
      this.moveToTags = false;
      this.userinfo = false;
    }
    else if (this.moveToBusiness) {
      this.section = 3;
      this.moveToQuestion = false;
      this.moveToBusiness = false;
      this.moveToTags = true;
      this.userinfo = false;
      this.setBusinessesIds(this.businessname.nativeElement.value, this.businessadress.nativeElement.value,
        this.accesscode.nativeElement.value, this.site.nativeElement.value);
      console.log(this.user);
    } else {
      return;
    }


  }



}
