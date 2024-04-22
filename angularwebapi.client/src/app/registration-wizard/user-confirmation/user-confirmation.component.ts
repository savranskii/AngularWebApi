import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatStepper } from '@angular/material/stepper';
import { RegistrationService } from '../services/registration.service';
import { NotificationService } from '../../services/notification.service';
import { InfoFormGroup } from '../models/InfoFormGroup';
import { ResidenceFormGroup } from '../models/ResidenceFormGroup';
import { RegistrationRequest } from '../models/RegistrationRequest';

@Component({
	selector: 'app-user-confirmation',
	templateUrl: './user-confirmation.component.html',
	styleUrl: './user-confirmation.component.css'
})
export class UserConfirmationComponent {
	@Input() stepper!: MatStepper;
	@Input() formStep1!: FormGroup<InfoFormGroup>;
	@Input() formStep2!: FormGroup<ResidenceFormGroup>;

	isSending: boolean = false;

	constructor(
		private _registrationService: RegistrationService,
		private _notificationService: NotificationService
	) { }

	save() {
		this.isSending = true;

		const request = {
			...this.formStep1.value,
			...this.formStep2.value
		};
		delete request.passwordConfirmation;

		this._registrationService.completeRegistration(request as RegistrationRequest).subscribe({
			next: () => {
				this.stepper.reset();
				this._notificationService.show('Successful registration!');
			},
			error: (error) => this._notificationService.show(`Unsuccessful registration! ${error.message}`),
			complete: () => this.isSending = false,
		});
	}
}
