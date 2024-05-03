import { FormControl } from "@angular/forms";

export type ResidenceFormGroup = {
	country: FormControl<number | null>;
	province: FormControl<number | null>;
}
