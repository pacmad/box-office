import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Show } from '../models/show';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class ShowsService {
    constructor(private http: HttpClient) {

    }

    add(show: Show) {
        return this.http.post<Show>(`${environment.apiUrl}/shows`, show);
    }

    get(id: number) {
        return this.http.get<Show>(`${environment.apiUrl}/shows/${id}`);
    }

    getAll() {
        return this.http.get<Show[]>(`${environment.apiUrl}/shows`);
    }
}