import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  images = ['../../assets/1.png', '../../assets/2.png', '../../assets/3.png'];
  constructor() { }

  ngOnInit(): void {
  }

}
