import {Component} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {InfoFormGroup} from '../models/InfoFormGroup';
import {ResidenceFormGroup} from '../models/ResidenceFormGroup';
import {confirmPasswordValidator} from '../../utils/validators/PasswordValidator';

@Component({
  selector: 'app-user-wizard',
  templateUrl: './user-wizard.component.html',
  styleUrl: './user-wizard.component.css',
})
export class UserWizardComponent {
  firstFormGroup = this._formBuilder.group({
    login: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.pattern(/^(?=.*[A-Za-z])(?=.*\d).+$/i)]],
    passwordConfirmation: ['', [Validators.required]],
    isAgreeToWorkForFood: [true, [Validators.required]]
  }, {validators: confirmPasswordValidator}) as FormGroup<InfoFormGroup>;

  secondFormGroup = this._formBuilder.group({
    country: [null, [Validators.required]],
    province: [null, [Validators.required]],
  }) as FormGroup<ResidenceFormGroup>;

  constructor(private _formBuilder: FormBuilder) {
  }
}
