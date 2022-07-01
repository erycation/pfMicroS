

import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { AuthToken } from '../model/loginDto/authToken';

@Injectable({ providedIn: 'root' })
export class AccountService {
    private userSubject: BehaviorSubject<AuthToken>;
    public user: Observable<AuthToken>;

    constructor(
        private router: Router,
        private http: HttpClient
    ) {
        this.userSubject = new BehaviorSubject<AuthToken>(JSON.parse(localStorage.getItem('user')));
        this.user = this.userSubject.asObservable();
    }

    public get userValue(): AuthToken {
        return this.userSubject.value;
    }

    login(username, password) {
        return this.http.post<AuthToken>(`${environment.apiUrl}Login`, { username, password })
            .pipe(map(user => {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('user', JSON.stringify(user));

                this.userSubject.next(user);

     
                return user;
            }));
    }

    logout() {
        // remove user from local storage and set current user to null
        localStorage.removeItem('user');
        this.userSubject.next(null);
        this.router.navigate(['login']);
    }
}