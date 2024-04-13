import { Component, OnInit } from '@angular/core';
import { MatIconRegistry } from '@angular/material/icon';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styles: []
})
export class AppComponent implements OnInit {
  constructor(
    private matIconReg: MatIconRegistry
  ) { }

  ngOnInit(): void {
    this.matIconReg.setDefaultFontSetClass('material-symbols-rounded')
  }
}
