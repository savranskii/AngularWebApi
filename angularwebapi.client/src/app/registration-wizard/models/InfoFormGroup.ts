import { FormControl } from "@angular/forms";

export type InfoFormGroup = {
	login: FormControl<string | null>;
	password: FormControl<string | null>;
	passwordConfirmation: FormControl<string | null>;
	isAgreeToWorkForFood: FormControl<boolean>;
}
