import { Component, Injector, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class FooterComponent{
  currentYear: number;

  constructor() {

    this.currentYear = new Date().getFullYear();
  }
}
