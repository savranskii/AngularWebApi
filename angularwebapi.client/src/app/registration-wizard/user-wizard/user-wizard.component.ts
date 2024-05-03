import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { ResidenceFormGroup } from '../models/ResidenceFormGroup';
import { confirmPasswordValidator } from '../../utils/validators/PasswordValidator';
import { InfoFormGroup } from '../models/InfoFormGroup';

@Component({
	selector: 'app-user-wizard',
	templateUrl: './user-wizard.component.html',
	styleUrl: './user-wizard.component.css',
})
export class UserWizardComponent {
	firstFormGroup = this._formBuilder.group<InfoFormGroup>({
		login: new FormControl('', [Validators.required, Validators.email]),
		password: new FormControl('', [Validators.required, Validators.pattern(/^(?=.*[A-Za-z])(?=.*\d).+$/i)]),
		passwordConfirmation: new FormControl('', [Validators.required]),
		isAgreeToWorkForFood: new FormControl(true, [Validators.required])
	}, { validators: confirmPasswordValidator });

	secondFormGroup = this._formBuilder.group<ResidenceFormGroup>({
		country: new FormControl(null, [Validators.required]),
		province: new FormControl(null, [Validators.required]),
	});

	constructor(private _formBuilder: FormBuilder) {
	}
}
