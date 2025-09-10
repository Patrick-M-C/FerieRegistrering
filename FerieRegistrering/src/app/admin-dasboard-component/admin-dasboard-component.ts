import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Vacation } from '../models/vacations';
import { VacationService } from '../services/vacation.service';

@Component({
  selector: 'app-admin-dasboard-component',
  imports: [CommonModule, FormsModule],
  standalone: true,
  templateUrl: './admin-dasboard-component.html',
  styleUrls: ['./admin-dasboard-component.css'],
})
export class AdminDasboardComponent {
  pending: Vacation[] = [];
  loading = false;
  error: string | null = null;

  constructor(private vacationService: VacationService) {}

  ngOnInit() {
    this.hentPending();
  }

  hentPending() {
    this.loading = true;
    this.vacationService.getPending().subscribe({
      next: (data) => {
        this.pending = data;
        this.loading = false;
      },
      error: (err) => {
        console.error(err);
        this.error = 'Kunne ikke hente ferieanmodninger.';
        this.loading = false;
      },
    });
  }

  godkend(id: number) {
    this.vacationService.approve(id, 'Godkendt af leder').subscribe({
      next: () => this.hentPending(),
      error: (err) => console.error(err),
    });
  }

  afvis(id: number) {
    this.vacationService.reject(id, 'Afvist af leder').subscribe({
      next: () => this.hentPending(),
      error: (err) => console.error(err),
    });
  }
}
