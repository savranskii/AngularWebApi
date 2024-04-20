import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatStepper } from '@angular/material/stepper';

@Component({
	selector: 'app-user-confirmation',
	templateUrl: './user-confirmation.component.html',
	styleUrl: './user-confirmation.component.css'
})
export class UserConfirmationComponent {
	@Input()
	stepper!: MatStepper;

	@Input()
	formStep1!: FormGroup;

	@Input()
	formStep2!: FormGroup;

	save() {
		for (let control in this.formStep1.controls)
			console.log(this.formStep1.controls[control].value);
	}
}
