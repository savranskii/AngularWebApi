import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserInfoComponent } from './user-info/user-info.component';
import { UserResidenceComponent } from './user-residence/user-residence.component';
import { UserWizardComponent } from './user-wizard/user-wizard.component';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSelectModule } from '@angular/material/select';
import { MatStepperModule } from '@angular/material/stepper';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatIconModule } from '@angular/material/icon';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { RegistrationCompleteComponent } from './registration-complete/registration-complete.component';
import { RegistrationWizardRoutingModule } from './registration-wizard-routing.module';

@NgModule({
	declarations: [
		UserInfoComponent,
		UserResidenceComponent,
		UserWizardComponent,
		RegistrationCompleteComponent,
	],
	exports: [
		UserWizardComponent,
	],
	imports: [
		CommonModule,
		MatButtonModule,
		MatFormFieldModule,
		MatCardModule,
		MatCheckboxModule,
		MatSelectModule,
		MatStepperModule,
		MatProgressSpinnerModule,
		MatIconModule,
		MatInputModule,
		FormsModule,
		ReactiveFormsModule,
		RegistrationWizardRoutingModule,
	]
})
export class RegistrationWizardModule {
}
