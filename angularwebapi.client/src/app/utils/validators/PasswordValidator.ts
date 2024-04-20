import { ValidatorFn, AbstractControl, ValidationErrors, FormGroup } from "@angular/forms";
import { InfoFormGroup } from "../../registration-wizard/models/InfoFormGroup";

export const confirmPasswordValidator: ValidatorFn = (controls: AbstractControl): ValidationErrors | null => {
	const isMatch = controls.value.password === controls.value.passwordConfirmation;

	if (!isMatch)
		(controls as FormGroup<InfoFormGroup>).controls.passwordConfirmation.setErrors({ min: true });

	return isMatch ? null : { passwordNoMatch: true };
};