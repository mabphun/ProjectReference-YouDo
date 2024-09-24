import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkLoggerComponent } from './work-logger.component';

describe('WorkLoggerComponent', () => {
  let component: WorkLoggerComponent;
  let fixture: ComponentFixture<WorkLoggerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WorkLoggerComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WorkLoggerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
