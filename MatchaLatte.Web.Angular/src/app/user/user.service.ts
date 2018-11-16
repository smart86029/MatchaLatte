import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { PaginationResult } from '../shared/pagination-result';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private usersUrl = 'identity/api/users';

  constructor(private httpClient: HttpClient) { }

  getUsers(pageIndex: number, pageSize: number): Observable<PaginationResult<User>> {
    const params = new HttpParams()
      .set('pageIndex', pageIndex.toString())
      .set('pageSize', pageSize.toString());

    return this.httpClient.get<User[]>(this.usersUrl, { params: params, observe: 'response' }).pipe(
      map(response => {
        const itemCount = +response.headers.get('X-Pagination');
        return new PaginationResult<User>(itemCount, response.body);
      }),
      catchError(this.handleError('getUsers', new PaginationResult<User>()))
    );
  }

  getUser(id: number): Observable<User> {
    return this.httpClient.get<User>(`${this.usersUrl}/${id}`).pipe(
      catchError(this.handleError('getUser', null))
    );
  }

  getNewUser(): Observable<User> {
    return this.httpClient.get<User>(`${this.usersUrl}/new`).pipe(
      catchError(this.handleError('getUser', null))
    );
  }

  createUser(user: User): Observable<User> {
    return this.httpClient.post<User>(`${this.usersUrl}`, user).pipe(
      catchError(this.handleError('createUser', user))
    );
  }

  updateUser(user: User): Observable<User> {
    return this.httpClient.put<User>(`${this.usersUrl}/${user.userId}`, user).pipe(
      catchError(this.handleError('updateUser', user))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);

      return of(result as T);
    };
  }
}
