import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Location } from '../models/Location';
import { ResidenceFormGroup } from '../models/ResidenceFormGroup';
import { LocationService } from '../services/location.service';
import { NotificationService } from '../../services/notification.service';

@Component({
	selector: 'app-user-residence',
	templateUrl: './user-residence.component.html',
	styleUrl: './user-residence.component.css'
})
export class UserResidenceComponent implements OnInit {
	@Input()
	formGroup!: FormGroup<ResidenceFormGroup>;

	isLoading: boolean = true;
	countries: Location[] = [];

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

  getProvinces(): string[] {
		console.log(this.formGroup.controls.country.value);
		return [];
	}
}
