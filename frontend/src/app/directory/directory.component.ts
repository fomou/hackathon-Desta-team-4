import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-directory',
  templateUrl: './directory.component.html',
  styleUrls: ['./directory.component.scss']
})
export class DirectoryComponent implements OnInit {

  businesses: any[];
  constructor() {
    this.businesses = [
      {
        name:'Maison du Cari des Caraïbes',
        adress: '6892, ave. Victoria, Montreal, QC',
        site: 'https://maisonducari.com/',
        src: '../../assets/maisoncanari.png',
        desciption: 'We proudly serve authentic Caribbean cuisine using select ingredients',
        tages: ['Restaurant'],
      },

      {
        name:'DESTA Black Youth Network',
        adress: '1950 St-Antoine W. Montreal, QC, H3J 1A5',
        site: 'https://destabyn.org/',
        src: '../../assets/desta.png',
        desciption: 'Non-Profit that empowers Black Youth in Montreal',
        tages: ['service'],
      },
    ]
   }

  ngOnInit(): void {
  }

}
