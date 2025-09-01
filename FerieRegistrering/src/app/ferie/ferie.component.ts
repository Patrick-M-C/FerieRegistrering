import { Component } from '@angular/core';

@Component({
  selector: 'app-ferie',
  templateUrl: './ferie.component.html',
  styleUrls: ['./ferie.component.css']
})
export class FerieComponent {
  currentYear = new Date().getFullYear();
  currentMonth = 0; // Januar = 0 (JavaScript måned index)

  // Dummy data – i praksis kunne du hente dette fra backend eller auth service
  reservedDays: { [key: string]: boolean } = {
    '2025-01-05': true,
    '2025-01-12': true,
    '2025-02-03': true,
  };

  get monthName(): string {
    return new Date(this.currentYear, this.currentMonth).toLocaleString('da-DK', { month: 'long' });
  }

  get daysInMonth(): number[] {
    const days = new Date(this.currentYear, this.currentMonth + 1, 0).getDate();
    return Array.from({ length: days }, (_, i) => i + 1);
  }

  isReserved(day: number): boolean {
    const dateKey = `${this.currentYear}-${String(this.currentMonth + 1).padStart(2, '0')}-${String(day).padStart(2, '0')}`;
    return this.reservedDays[dateKey] || false;
  }

  prevMonth() {
    if (this.currentMonth === 0) {
      this.currentMonth = 11;
      this.currentYear--;
    } else {
      this.currentMonth--;
    }
  }

  nextMonth() {
    if (this.currentMonth === 11) {
      this.currentMonth = 0;
      this.currentYear++;
    } else {
      this.currentMonth++;
    }
  }
}
