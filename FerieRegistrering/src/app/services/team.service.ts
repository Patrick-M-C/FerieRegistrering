import { Injectable } from '@angular/core';
import { environment } from '../Environments/environments';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Team } from '../models/team';

@Injectable({ providedIn: 'root' })
export class TeamService {
  private readonly teamsApiUrl = environment.apiUrl + '/Teams';

  constructor(private http: HttpClient) {}

  getAllTeams(): Observable<Team[]> {
    return this.http.get<Team[]>(this.teamsApiUrl);
  }

  getTeamById(id: number): Observable<Team> {
    return this.http.get<Team>(`${this.teamsApiUrl}/${id}`);
  }

  getMyTeam(): Observable<Team | null> {
    return this.http.get<Team | null>(`${this.teamsApiUrl}/me`);
  }

}
