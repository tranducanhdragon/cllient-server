import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  currentYear: number = new Date().getFullYear();
  constructor() { }

  ngOnInit(): void {
  }

}
