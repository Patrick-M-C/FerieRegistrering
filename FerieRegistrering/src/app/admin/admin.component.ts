import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { resetUser, User } from '../models/user';
import { UserService } from '../services/user.service';
import { Team } from '../models/team';                
import { TeamService } from '../services/team.service'; 
import { RouterLink } from '@angular/router';
import { switchMap, of, forkJoin } from 'rxjs';

@Component({
  selector: 'app-admin',
  standalone: true,
  templateUrl: './admin.component.html',
  imports: [CommonModule, FormsModule, RouterLink],
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  users: User[] = [];
  editingUser: User | null = null;
  user: User = resetUser();
  creating = false;

  // Team-opslag: userId -> { teamId, name }
  private teamByUserId = new Map<number, { teamId: number; name: string }>();
  selectedUserId: number | null = null;
  loadingTeams = false;

  constructor(
    private userService: UserService,
    private teamService: TeamService
  ) {}

  ngOnInit(): void {
    this.loadUsers();
    this.loadTeams();
  }

  // --- Users ---
  loadUsers() {
    this.userService.getAllUsers().subscribe({
      next: (data) => { this.users = data; },
      error: (error) => { console.error('Error fetching users:', error); }
    });
  }

  editUser(user: User) {
    this.editingUser = { ...user }; 
  }

  startCreate() {
    this.user = resetUser();
    this.creating = true;
  }

  createUser() {
    this.userService.createUser(this.user).subscribe({
      next: (newUser) => {
        this.users.push(newUser);
        this.creating = false;
        this.user = resetUser();
      },
      error: (error) => console.error('Error creating user:', error)
    });
  }

  cancelCreate() {
    this.creating = false;
    this.user = resetUser();
  }

  openEdit(user: User) {
    this.editingUser = { ...user }; 
  }

  saveUser() {
    if (!this.editingUser) return;

    this.userService.updateUser(this.editingUser).subscribe({
      next: () => {
        this.loadUsers();
        this.editingUser = null;
      },
      error: (error) => console.error('Error Kan ikke opdatere user:', error)
    });
  }

  deleteUser(id: number) {
    if (!confirm('Er du sikker på at du vil slette denne bruger?')) return;

    this.userService.deleteUser(id).subscribe({
      next: () => this.loadUsers(),
      error: (error) => console.error('Error Kan ikke slette brugere', error)
    });
  }

  closeEdit() {
    this.editingUser = null;
  }

  // --- Teams ---
loadTeams() {
  this.loadingTeams = true;

  this.teamService.getAllTeams().pipe(
    switchMap(teams => {
      if (!teams || teams.length === 0) return of([] as Team[]);
      // Hent detaljer for hvert team (GET /api/Teams/{id}) som indeholder members
      return forkJoin(teams.map(t => this.teamService.getTeamById(t.teamId)));
    })
  ).subscribe({
    next: (teamsWithMembers: Team[]) => {
      this.teamByUserId.clear();
      for (const t of teamsWithMembers) {
        for (const m of (t.members || [])) {
          this.teamByUserId.set(m.id, { teamId: t.teamId, name: t.name });
        }
      }
      this.loadingTeams = false;
    },
    error: (err) => {
      console.error('Fejl ved hentning af teams:', err);
      this.loadingTeams = false;
    }
  });
}

  getTeamName(userId: number): string | null {
    return this.teamByUserId.get(userId)?.name ?? null;
  }

  getTeamId(userId: number): number | null {
    return this.teamByUserId.get(userId)?.teamId ?? null;
  }

  toggleDetails(userId: number) {
    this.selectedUserId = this.selectedUserId === userId ? null : userId;
  }
}
