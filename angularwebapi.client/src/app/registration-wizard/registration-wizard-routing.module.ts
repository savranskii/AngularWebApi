import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserWizardComponent } from './user-wizard/user-wizard.component';
import { RegistrationCompleteComponent } from './registration-complete/registration-complete.component';


const routes: Routes = [
	{ path: '', component: UserWizardComponent },
	{ path: 'done', component: RegistrationCompleteComponent }
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule]
})
export class RegistrationWizardRoutingModule {
}
