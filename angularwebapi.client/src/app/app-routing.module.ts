import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

const routes: Routes = [
	{ path: '', redirectTo: '/registration', pathMatch: 'full' },
	{
		path: 'registration',
		loadChildren: () => import('./registration-wizard/registration-wizard.module').then(m => m.RegistrationWizardModule)
	},
	{ path: '**', component: PageNotFoundComponent }
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
})
export class AppRoutingModule { }
