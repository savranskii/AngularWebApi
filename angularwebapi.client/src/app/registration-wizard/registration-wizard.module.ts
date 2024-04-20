import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserInfoComponent } from './user-info/user-info.component';
import { UserResidenceComponent } from './user-residence/user-residence.component';
import { UserWizardComponent } from './user-wizard/user-wizard.component';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select';
import { MatStepperModule } from '@angular/material/stepper';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { UserConfirmationComponent } from './user-confirmation/user-confirmation.component';

@NgModule({
	declarations: [
		UserInfoComponent,
		UserResidenceComponent,
		UserWizardComponent,
		UserConfirmationComponent,
	],
	exports: [
		UserWizardComponent,
	],
	imports: [
		CommonModule,
		MatButtonModule,
		MatFormFieldModule,
		MatCardModule,
		MatSelectModule,
		MatStepperModule,
		MatProgressSpinnerModule,
		MatInputModule,
		FormsModule,
		ReactiveFormsModule,
	]
})
export class RegistrationWizardModule { }
