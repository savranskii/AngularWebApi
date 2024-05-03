import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Country } from '../models/Country';
import { ResidenceFormGroup } from '../models/ResidenceFormGroup';
import { LocationService } from '../services/location.service';
import { NotificationService } from '../../services/notification.service';
import { InfoFormGroup } from '../models/InfoFormGroup';
import { RegistrationService } from '../services/registration.service';
import { RegistrationRequest } from '../models/RegistrationRequest';
import { MatStepper } from '@angular/material/stepper';
import { Province } from '../models/Province';
import { MatSelectChange } from '@angular/material/select';
import { Router } from '@angular/router';
import { ResponseError } from '../../models/ResponseError';

@Component({
	selector: 'app-user-residence',
	templateUrl: './user-residence.component.html',
	styleUrl: './user-residence.component.css'
})
export class UserResidenceComponent implements OnInit {
	@Input({ required: true }) stepper!: MatStepper;
	@Input({ required: true }) firstFormGroup!: FormGroup<InfoFormGroup>;
	@Input({ required: true }) secondFormGroup!: FormGroup<ResidenceFormGroup>;

	isSending: boolean = false;
	isLoading: boolean = true;
	countries: Country[] = [];
	provinces: Province[] = [];

	constructor(
		private _locationService: LocationService,
		private _registrationService: RegistrationService,
		private _notificationService: NotificationService,
		private _router: Router
	) {
	}

	ngOnInit(): void {
		this._locationService.getCountries().subscribe({
			next: (countries) => {
				this.countries = countries;
			},
			error: (error) => this._notificationService.show((error.error as ResponseError).detail),
			complete: () => this.isLoading = false,
		});
	}

	loadProvinces(e: MatSelectChange): void {
		this.isLoading = true;
		const countryId = e.value;

		if (countryId == null)
			this.provinces = [];

		this.secondFormGroup.controls.province.setValue(null);
		this._locationService.getProvinces(countryId as number).subscribe({
			next: (provinces) => {
				this.provinces = provinces;
			},
			error: (error) => this._notificationService.show((error.error as ResponseError).detail),
			complete: () => this.isLoading = false,
		});
	}

	hasCountryError(): boolean {
		return this.secondFormGroup.controls.country.invalid &&
			this.secondFormGroup.controls.country.dirty &&
			this.secondFormGroup.controls.country.errors != null;
	}

	hasProvinceError(): boolean {
		return this.secondFormGroup.controls.province.invalid &&
			this.secondFormGroup.controls.province.dirty &&
			this.secondFormGroup.controls.province.errors != null;
	}

	save() {
		if (!this.firstFormGroup.valid || !this.secondFormGroup.valid) {
			this._notificationService.show('Form is not valid. Please check required fields.');
			return;
		}

		this.isSending = true;

		const request = {
			login: this.firstFormGroup.controls.login.value,
			password: this.firstFormGroup.controls.password.value,
			isAgreeToWorkForFood: this.firstFormGroup.controls.isAgreeToWorkForFood.value,
			country: this.secondFormGroup.controls.country.value,
			province: this.secondFormGroup.controls.province.value,
		} as RegistrationRequest;

		this._registrationService.completeRegistration(request).subscribe({
			next: () => {
				this.stepper.reset();
				this.isSending = false;
				this._router.navigate(['/registration/done']);
			},
			error: (error) => {
				this._notificationService.show((error.error as ResponseError).detail);
				this.isSending = false;
			}
		});
	}
}
