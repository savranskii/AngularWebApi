import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatStepper } from '@angular/material/stepper';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
	selector: 'app-user-confirmation',
	templateUrl: './user-confirmation.component.html',
	styleUrl: './user-confirmation.component.css'
})
export class UserConfirmationComponent {
	@Input() stepper!: MatStepper;
	@Input() formStep1!: FormGroup;
	@Input() formStep2!: FormGroup;

	isSending: boolean = false;

	constructor(private _snackBar: MatSnackBar, private _http: HttpClient) { }

	save() {
		this.isSending = true;

		const formData = new FormData();
		formData.append('login', this.formStep1.controls['login'].value);
		formData.append('password', this.formStep1.controls['password'].value);
		formData.append('country', this.formStep2.controls['country'].value);
		formData.append('province', this.formStep2.controls['province'].value);

		this._http.post('/registration', formData).subscribe({
			next: () => {
				this.stepper.reset();
				this.openSnackBar('Success registration!');
				this.isSending = false;
			},
			error: (error) => {
				this.openSnackBar(`Unsuccess registration! ${error.message}`);
				this.isSending = false;
			}
		});
	}

	openSnackBar(message: string) {
    this._snackBar.open(message, 'Close');
  }
}
