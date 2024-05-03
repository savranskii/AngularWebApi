import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserResidenceComponent } from './user-residence.component';

describe('UserResidenceComponent', () => {
	let component: UserResidenceComponent;
	let fixture: ComponentFixture<UserResidenceComponent>;

	beforeEach(async () => {
		await TestBed.configureTestingModule({
			declarations: [UserResidenceComponent]
		})
			.compileComponents();

		fixture = TestBed.createComponent(UserResidenceComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
