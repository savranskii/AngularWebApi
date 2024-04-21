import { ComponentFixture, TestBed } from '@angular/core/testing';
import { UserConfirmationComponent } from './user-confirmation.component';
import { FormControl, FormGroup } from '@angular/forms';
import { InfoFormGroup } from '../models/InfoFormGroup';
import { ResidenceFormGroup } from '../models/ResidenceFormGroup';

describe('UserConfirmationComponent', () => {
  let component: UserConfirmationComponent;
  let fixture: ComponentFixture<UserConfirmationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UserConfirmationComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UserConfirmationComponent);
    component = fixture.componentInstance;
    component.formStep1 = new FormGroup({
      login: new FormControl('test@mail.com'),
      password: new FormControl('123'),
      passwordConfirmation: new FormControl('123')
    }) as FormGroup<InfoFormGroup>;
    component.formStep2 = new FormGroup({
      country: new FormControl('Country 1'),
      province: new FormControl('Province 1'),
    }) as FormGroup<ResidenceFormGroup>;

    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should show forms group data', () => {
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled).withContext('test@mail.com').not.toBe(null);
    expect(compiled).withContext('123').not.toBe(null);
    expect(compiled).withContext('Country 1').not.toBe(null);
    expect(compiled).withContext('Province 1').not.toBe(null);
  });
});
