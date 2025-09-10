import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../Environments/environments';
import { Vacation } from '../models/vacations';

@Injectable({ providedIn: 'root' }) // <- vigtigt!
export class VacationService {
  private readonly apiUrl = environment.apiUrl + '/Leaves';

  constructor(private http: HttpClient) {}

  getMine(): Observable<Vacation[]> {
    return this.http.get<Vacation[]>(`${this.apiUrl}/mine`);
  }

  requestVacation(startDate: string, endDate: string, reason: string) {
    return this.http.post<Vacation>(`${this.apiUrl}/request`, {
      startDate,
      endDate,
      reason,
    });
  }

  getPending() {
    return this.http.get<Vacation[]>(`${this.apiUrl}/pending`);
  }

  approve(id: number, comment: string) {
    return this.http.put(`${this.apiUrl}/approve/${id}`, {
      managerComment: comment,
    });
  }

  reject(id: number, comment: string) {
    return this.http.put(`${this.apiUrl}/reject/${id}`, {
      managerComment: comment,
    });
  }
}
