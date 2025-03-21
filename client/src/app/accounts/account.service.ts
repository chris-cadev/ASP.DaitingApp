import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { User } from './user.model';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private http = inject(HttpClient);
  baseUrl = 'https://localhost:5001/api/';
  private _currentUser = signal<User | null>(null);

  get user() {
    return this._currentUser();
  }

  constructor() {
    this.loadPersistedUser();
  }

  private loadPersistedUser() {
    const userString = localStorage.getItem('user');
    if (!userString) return;
    const user = JSON.parse(userString);
    this._currentUser.set(user);
  }

  login(model: any) {
    return this.http.post(`${this.baseUrl}account/login`, model).pipe(
      map((user) => {
        if (!user) return user;
        localStorage.setItem('user', JSON.stringify(user));
        this._currentUser.set(user as User);
      })
    )
  }

  logout() {
    localStorage.removeItem('user');
    this._currentUser.set(null);
  }
}
