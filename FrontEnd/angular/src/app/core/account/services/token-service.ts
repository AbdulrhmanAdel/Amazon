import {Injectable} from "@angular/core";


@Injectable({providedIn: 'root'})
export class TokenService {
  saveToken(token: string, rememberIt: boolean = true) {
    if (rememberIt) {
      localStorage.setItem('token', token);
      return;
    }
    sessionStorage.setItem('token', token);
  }

  removeToken() {
    localStorage.removeItem('token');
    sessionStorage.removeItem('token');
  }

  getToken(): string | null {
    return localStorage.getItem('token') ?? sessionStorage.getItem('token');
  }

  isTokenExists(): boolean {
    return this.getToken() != null;
  }
}
