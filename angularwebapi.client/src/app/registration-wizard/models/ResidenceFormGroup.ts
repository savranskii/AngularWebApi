import { FormControl } from "@angular/forms";

export interface ResidenceFormGroup {
	country: FormControl<number | null>;
	province: FormControl<number | null>;
}
