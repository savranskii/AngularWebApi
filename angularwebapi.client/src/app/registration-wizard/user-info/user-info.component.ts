import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
	selector: 'app-user-info',
	templateUrl: './user-info.component.html',
	styleUrl: './user-info.component.css'
})
export class UserInfoComponent {
	@Input({ required: true }) formGroup!: FormGroup;

	isUsed(controlName: string): boolean {
		return this.formGroup.controls[controlName].invalid &&
			this.formGroup.controls[controlName].dirty;
	}

	hasError(controlName: string): boolean {
		return this.isUsed(controlName) && this.formGroup.controls[controlName].errors != null;
	}
}
