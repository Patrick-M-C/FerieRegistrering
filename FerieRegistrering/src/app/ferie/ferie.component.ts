import { Component } from '@angular/core';

@Component({
  selector: 'app-ferie',
  templateUrl: './ferie.component.html',
  styleUrls: ['./ferie.component.css']
})
export class FerieComponent {
  startDato: string = '';
  slutDato: string = '';
  kommentar: string = '';
  registreringer: any[] = [];

  gemFerie() {
    if (!this.startDato || !this.slutDato) {
      alert('Udfyld venligst både start- og slutdato.');
      return;
    }

    this.registreringer.push({
      start: this.startDato,
      slut: this.slutDato,
      kommentar: this.kommentar
    });

    // Nulstil formularen
    this.startDato = '';
    this.slutDato = '';
    this.kommentar = '';
  }
}
