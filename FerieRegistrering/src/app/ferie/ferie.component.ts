import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { VacationService } from '../services/vacation.service';
import { Vacation } from '../models/vacations';

type VacationStatus = 'Pending' | 'Approved' | 'Rejected';

@Component({
  selector: 'app-ferie',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './ferie.component.html',
  styleUrls: ['./ferie.component.css']
})
export class FerieComponent implements OnInit {
  currentYear = new Date().getFullYear();
  currentMonth = new Date().getMonth();

  ferier: (Vacation & { status: VacationStatus })[] = [];
  startDato = '';
  slutDato = '';
  reason = '';
  loading = false;
  error: string | null = null;

  // Tekst til badges
  statusText: Record<VacationStatus, string> = {
    Pending: 'Afventer',
    Approved: 'Godkendt',
    Rejected: 'Afvist'
  };

  constructor(private vacationService: VacationService) {}

  ngOnInit() {
    this.getMyVacations();
  }

  // Normaliser status (understøtter både tal og strings fra backend)
  private normalizeStatus(s: any): VacationStatus {
    const map: any = {
      0: 'Pending', 1: 'Approved', 2: 'Rejected',
      Pending: 'Pending', Approved: 'Approved', Rejected: 'Rejected'
    };
    return (map[s] ?? 'Pending') as VacationStatus;
  }

  getMyVacations() {
    this.loading = true;
    this.error = null;
    this.vacationService.getMine().subscribe({
      next: (data) => {
        this.ferier = data.map(v => ({ ...v, status: this.normalizeStatus((v as any).status) }));
        this.loading = false;
      },
      error: () => {
        this.error = 'Kunne ikke hente ferieoplysninger.';
        this.loading = false;
      }
    });
  }

  saveVacation() {
    if (!this.startDato || !this.slutDato) return;
    this.error = null;

    this.vacationService.requestVacation(this.startDato, this.slutDato, this.reason).subscribe({
      next: (ferie) => {
        this.ferier = [...this.ferier, { ...ferie, status: this.normalizeStatus((ferie as any).status) }];
        this.startDato = this.slutDato = this.reason = '';
      },
      error: () => this.error = 'Kunne ikke gemme ferie.'
    });
  }

  get monthName(): string {
    return new Date(this.currentYear, this.currentMonth).toLocaleString('da-DK', { month: 'long' });
  }

  get daysInMonth(): number[] {
    const days = new Date(this.currentYear, this.currentMonth + 1, 0).getDate();
    return Array.from({ length: days }, (_, i) => i + 1);
  }

  isReserved(day: number): boolean {
    const date = new Date(this.currentYear, this.currentMonth, day).toISOString().slice(0, 10); // YYYY-MM-DD
    return this.ferier.some(f => date >= f.startDate && date <= f.endDate);
  }

  changeMonth(delta: number) {
    const d = new Date(this.currentYear, this.currentMonth + delta, 1);
    this.currentYear = d.getFullYear();
    this.currentMonth = d.getMonth();
  }

  badgeClass(s: VacationStatus) {
    return {
      'bg-success': s === 'Approved',
      'bg-warning text-dark': s === 'Pending',
      'bg-danger': s === 'Rejected'
    };
  }
}
