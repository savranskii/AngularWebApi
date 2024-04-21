import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Country } from '../models/Country';
import { ResidenceFormGroup } from '../models/ResidenceFormGroup';
import { LocationService } from '../services/location.service';
import { NotificationService } from '../../services/notification.service';
import { Province } from '../models/Province';

@Component({
	selector: 'app-user-residence',
	templateUrl: './user-residence.component.html',
	styleUrl: './user-residence.component.css'
})
export class UserResidenceComponent implements OnInit {
	@Input()
	formGroup!: FormGroup<ResidenceFormGroup>;

	isLoading: boolean = true;
	countries: Country[] = [];

	constructor(
		private _locationService: LocationService,
		private _notificationService: NotificationService
	) { }

	ngOnInit(): void {
		this._locationService.getLocations().subscribe({
			next: (countries) => {
				this.countries = countries;
			},
			error: (error) => this._notificationService.show(`Unable to retrieve locations! ${error.message}`),
			complete: () => this.isLoading = false,
		});
	}

	getProvinces(): Province[] {
		console.log(this.formGroup.controls.country.value);
		return [];
	}
}
