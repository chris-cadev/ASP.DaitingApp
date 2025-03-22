import { Component, inject, OnInit } from '@angular/core';
import { RegisterComponent } from "../accounts/register.component";
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  imports: [RegisterComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {
  http = inject(HttpClient);
  users: any;
  registerMode = false;

  registerToggle() {
    this.registerMode = !this.registerMode;
  }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
    this.http.get('http://localhost:5000/api/users').subscribe({
      next: (response) => { this.users = response },
      error: console.log,
      complete: () => { console.log('Request has completed') },
    });
  }

  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }
}
