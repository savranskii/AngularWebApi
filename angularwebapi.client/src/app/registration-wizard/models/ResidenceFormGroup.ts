import { FormControl } from "@angular/forms";

export interface ResidenceFormGroup {
  country: FormControl<string | null>;
  province: FormControl<string | null>;
}
