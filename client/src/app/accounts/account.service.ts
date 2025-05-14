import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { User } from './user.model';
import { map } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private http = inject(HttpClient);
  baseUrl = environment.apiUrl;
  private _currentUser = signal<User | null>(null);

  get user() {
    return this._currentUser();
  }

  constructor() {
    this.loadPersistedUser();
  }

  register(model: any) {
    return this.http.post(this.endpoint('register'), model).pipe(this.mapToStoreUser);
  }

  login(model: any) {
    return this.http.post(this.endpoint('login'), model).pipe(this.mapToStoreUser);
  }

  logout() {
    localStorage.removeItem('user');
    this._currentUser.set(null);
  }

  private loadPersistedUser() {
    const userString = localStorage.getItem('user');
    if (!userString) return;
    const user = JSON.parse(userString);
    this._currentUser.set(user);
  }

  private storeUser = (user: any) => {
    if (!user) return user;
    localStorage.setItem('user', JSON.stringify(user));
    this._currentUser.set(user);
    return user;
  }

  private mapToStoreUser = map(this.storeUser);

  private endpoint(path: string) {
    return `${this.baseUrl}account/${path}`;
  }
}
