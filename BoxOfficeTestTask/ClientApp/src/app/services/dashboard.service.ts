import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Show } from '../models/show';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class DashboardService {

    constructor(private http: HttpClient) {

    }

    getShows() {
        return this.http.get<Show[]>(`${environment.apiUrl}/dashboard`);
    }
}