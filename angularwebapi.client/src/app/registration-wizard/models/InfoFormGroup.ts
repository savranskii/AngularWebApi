import { FormControl } from "@angular/forms";

export interface InfoFormGroup {
  login: FormControl<string | null>;
  password: FormControl<string | null>;
	passwordConfirmation: FormControl<string | null>;
	isAgreeToWorkForFood: FormControl<boolean>;
}
