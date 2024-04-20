import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { InfoFormGroup } from '../models/InfoFormGroup';
import { ResidenceFormGroup } from '../models/ResidenceFormGroup';
import { confirmPasswordValidator } from '../../utils/validators/PasswordValidator';

@Component({
	selector: 'app-user-wizard',
	templateUrl: './user-wizard.component.html',
	styleUrl: './user-wizard.component.css',
})
export class UserWizardComponent {
	firstFormGroup = new FormGroup<InfoFormGroup>({
		login: new FormControl('', [Validators.required, Validators.email]),
		password: new FormControl('', [Validators.required]),
		passwordConfirmation: new FormControl('', [Validators.required])
	}, { validators: confirmPasswordValidator });
	secondFormGroup = new FormGroup<ResidenceFormGroup>({
		country: new FormControl('', [Validators.required]),
		province: new FormControl('', [Validators.required]),
	});
}
