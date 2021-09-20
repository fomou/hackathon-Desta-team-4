import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-forum',
  templateUrl: './forum.component.html',
  styleUrls: ['./forum.component.scss']
})
export class ForumComponent implements OnInit {

  postIndex = 0;
  posts = [
    {
      user: 'https://bootdey.com/img/Content/avatar/avatar1.png',
      subject: 'Barbershop CDN',
      text: 'lorem ipsum dolor sit amet lorem ipsum dolor sit amet lorem ipsum dolor sit amet',
      replyothor: 'drewdan',
      timereply: '1 hours ago',
      view: 10,
      comment: 3,
      question: ' salut la communauté ! c\'un reel plaisir d\'utiliser ce platform :) je suis un nouveau à montreal je cherche un coifeur pour homme dans à cote-des-neige',
      reply: 'Bonjour! le plaisir est partagé!! il y a un coiffeur Haitien au 1234 cote-des-neiges ! je me suis deja coiffeur chez lui et tous les clients parlent très bien de lui'
    },

    {
      user: 'https://bootdey.com/img/Content/avatar/avatar1.png',
      subject: 'recevoir credit d\'import',
      text: 'lorem ipsum dolor sit amet lorem ipsum dolor sit amet lorem ipsum dolor sit amet',
      replyothor: 'Amadou',
      timereply: '1 hours ago',
      view: 10,
      comment: 3,
      question: 'I\'m newbie with laravel and i want to fetch data from database in realtime for my dashboard anaytics and i found a solution with ajax but it dosen\'t work if any one have a simple solution it will behelpful',
      reply: '',
    },

    {
      user: 'https://bootdey.com/img/Content/avatar/avatar2.png',
      subject: 'find Governement support for you business',
      text: 'lorem ipsum dolor sit amet lorem ipsum dolor sit amet lorem ipsum dolor sit amet',
      replyothor: 'Kassandra',
      timereply: '1 hours ago',
      view: 10,
      comment: 3,
      question: 'I\'m newbie with laravel and i want to fetch data from database in realtime for my dashboard anaytics and i found a solution with ajax but it dosen\'t work if any one have a simple solution it will behelpful',
      reply: '',
    },

    {
      user: 'https://bootdey.com/img/Content/avatar/avatar3.png',
      subject: 'comment augmenter ma cote à la bourse de montréal',
      text: 'lorem ipsum dolor sit amet lorem ipsum dolor sit amet lorem ipsum dolor sit amet',
      replyothor: 'Yangoye',
      timereply: '1 hours ago',
      view: 10,
      comment: 3,
      question: 'I\'m newbie with laravel and i want to fetch data from database in realtime for my dashboard anaytics and i found a solution with ajax but it dosen\'t work if any one have a simple solution it will behelpful',
      reply: '',
    },
  ];

  constructor() { }

  ngOnInit(): void {
  }

  setIndex(ind: number) {
    this.postIndex = ind;
  }

  addPost(title: string, question: string): void{
    console.log(question)
    this.posts.unshift({
      user: '../../assets/avatar.png',
      subject: title,
      text: 'lorem ipsum dolor sit amet',
      replyothor: '',
      timereply: '',
      view: 0,
      comment: 0,
      question: question,
      reply: ''
    });

  }

}
