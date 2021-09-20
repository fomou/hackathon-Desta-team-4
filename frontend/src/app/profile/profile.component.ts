import { Component, OnInit } from '@angular/core';
import { CommunicationService } from '../communication.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  kassandra = {
    username: 'Kassandra',
    email: 'kassadra@email,ca'
  };
  constructor(private communicationService: CommunicationService) {
    this.communicationService.currentUser.asObservable().subscribe(user => {
      this.kassandra = user;
    });
  }

  ngOnInit(): void {
  }

}
