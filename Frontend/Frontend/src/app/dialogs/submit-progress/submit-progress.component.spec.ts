import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubmitProgressComponent } from './submit-progress.component';

describe('SubmitProgressComponent', () => {
  let component: SubmitProgressComponent;
  let fixture: ComponentFixture<SubmitProgressComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SubmitProgressComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SubmitProgressComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
