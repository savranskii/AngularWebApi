import {Component} from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-registration-complete',
  templateUrl: './registration-complete.component.html',
  styleUrl: './registration-complete.component.css'
})
export class RegistrationCompleteComponent {
  constructor(private _router: Router) {
  }

  navigateToHome(): void {
    this._router.navigate(['/']);
  }
}
