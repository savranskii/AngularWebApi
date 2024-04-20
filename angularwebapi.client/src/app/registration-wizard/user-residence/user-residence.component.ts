import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Country } from '../models/Country';
import { ResidenceFormGroup } from '../models/ResidenceFormGroup';
import { Province } from '../models/Province';

@Component({
	selector: 'app-user-residence',
	templateUrl: './user-residence.component.html',
	styleUrl: './user-residence.component.css'
})
export class UserResidenceComponent {
	@Input()
	formGroup!: FormGroup<ResidenceFormGroup>;

	countries: Country[] = [{ name: 'test', value: 'test', provinces: [{ name: 'prov', value: 'prov' }] }];

	provinces: Province[] = [{ name: 'prov', value: 'prov' }];
}
