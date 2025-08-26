import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-ferie',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './ferie.component.html',
  styleUrls: ['./ferie.component.css']
})
export class FerieComponent {
  startDato = '';
  slutDato = '';
  kommentar = '';
  ferier: any[] = [];

  gemFerie() {
    this.ferier.push({
      startDato: this.startDato,
      slutDato: this.slutDato,
      kommentar: this.kommentar
    });

    this.startDato = '';
    this.slutDato = '';
    this.kommentar = '';
  }
}
