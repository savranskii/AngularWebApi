import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatStepper } from '@angular/material/stepper';
import { RegistrationService } from '../services/registration.service';
import { NotificationService } from '../../services/notification.service';

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

	constructor(
		private _registrationService: RegistrationService,
		private _notificationService: NotificationService
	) { }

	save() {
		this.isSending = true;

		const request = {
			login: this.formStep1.controls['login'].value,
			password: this.formStep1.controls['password'].value,
			country: this.formStep2.controls['country'].value,
			province: this.formStep2.controls['province'].value,
		};

		this._registrationService.completeRegistration(request).subscribe({
			next: () => {
				this.stepper.reset();
				this._notificationService.show('Success registration!');
			},
			error: (error) => this._notificationService.show(`Unsuccess registration! ${error.message}`),
			complete: () => this.isSending = false,
		});
	}
}
