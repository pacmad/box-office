import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { User } from '../models/user';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {

    private currentUserKey = 'currentUser';

    private currentUserSubject: BehaviorSubject<User>;
    public currentUser: Observable<User>;

    constructor(private http: HttpClient) {
        this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem(this.currentUserKey)));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get CurrentUserValue() {
        return this.currentUserSubject.value;
    }

    login(login: string, password: string) {
        return this.http.post<any>(`${environment.apiUrl}/auth/login`, { login, password })
            .pipe(map(user => {
                localStorage.setItem(this.currentUserKey, JSON.stringify(user));
                this.currentUserSubject.next(user);
                return user;
            }));
    }

    logout() {
        localStorage.removeItem(this.currentUserKey);
        this.currentUserSubject.next(null);
    }

}