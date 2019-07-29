import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private tokensUrl = 'identity/api/token';
  private tokenKey = 'access_token';

  constructor(private httpClient: HttpClient, private jwtHelper: JwtHelperService) { }

  signIn(userName: string, password: string): Observable<void> {
    const body = {
      UserName: userName,
      Password: password
    };

    return this.httpClient.post(this.tokensUrl, body).pipe(
      tap(data => localStorage.setItem(this.tokenKey, data[this.tokenKey])),
      map(() => { return; })
    );
  }

  signOut(): void {
    localStorage.removeItem(this.tokenKey);
  }

  isAuthorized(): boolean {
    return !this.jwtHelper.isTokenExpired();
  }
}
