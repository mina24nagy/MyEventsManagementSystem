import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EventService } from '../event.service';
import { Event } from '../event.model';

@Component({
  selector: 'app-event-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  template: `
    <h2>{{ isEditMode ? 'Edit Event' : 'Create Event' }}</h2>
    <form [formGroup]="eventForm" (ngSubmit)="onSubmit()">
      <label>
        Name:
        <input formControlName="name" />
      </label>
      <label>
        Description:
        <textarea formControlName="description"></textarea>
      </label>
      <label>
        Start Date:
        <input type="date" formControlName="startDate" />
      </label>
      <label>
        End Date:
        <input type="date" formControlName="endDate" />
      </label>
      <label>
        Location:
        <input formControlName="location" />
      </label>
      <label>
        Capacity:
        <input type="number" formControlName="capacity" />
      </label>
      <button type="submit">{{ isEditMode ? 'Update' : 'Create' }}</button>
    </form>
  `,
  styles: [`
  h2 {
    text-align: center;
    margin-bottom: 1rem;
  }
  
  .event-form {
    max-width: 500px;
    margin: 0 auto;
  }
  
  .form-group {
    margin-bottom: 1rem;
  }
  
  label {
    display: block;
    margin-bottom: 0.5rem;
    font-weight: bold;
  }
  
  input,
  textarea {
    width: 100%;
    padding: 0.5rem;
    border: 1px solid #ccc;
    border-radius: 4px;
  }
  
  textarea {
    resize: vertical;
  }
  
  button {
    padding: 0.5rem 1rem;
    margin-top: 1rem;
    cursor: pointer;
  }
  
  button[type="submit"] {
    background-color: #007bff;
    color: white;
    border: none;
    border-radius: 4px;
  }
  
  button[type="submit"]:hover {
    background-color: #0056b3;
  }
  
  .cancel-btn {
    background-color: #6c757d;
    color: white;
    border: none;
    border-radius: 4px;
    margin-left: 0.5rem;
  }
  
  .cancel-btn:hover {
    background-color: #5a6268;
  }
  
  .error {
    color: red;
    font-size: 0.875rem;
  }
  `]
})
export class EventFormComponent implements OnInit {
  eventForm: FormGroup;
  isEditMode = false;
  eventId: string | null = null;

  constructor(
    private fb: FormBuilder,
    private eventService: EventService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.eventForm = this.fb.group({
      name: ['', Validators.required],
      description: [''],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
      location: [''],
      capacity: [0, [Validators.required, Validators.min(1)]],
    });
  }

  ngOnInit(): void {
    this.eventId = this.route.snapshot.paramMap.get('id');
    if (this.eventId) {
      this.isEditMode = true;
      this.eventService.getEventById(this.eventId).subscribe({
        next: (event) => this.eventForm.patchValue(event),
        error: (err) => console.error('Error fetching event:', err),
      });
    }
  }

  onSubmit(): void {
    if (this.eventForm.invalid) return;

    const event: Event = this.eventForm.value;

    if (this.isEditMode) {
      this.eventService.updateEvent(this.eventId!, event).subscribe({
        next: () => this.router.navigate(['/']),
        error: (err) => console.error('Error updating event:', err),
      });
    } else {
      this.eventService.createEvent(event).subscribe({
        next: () => this.router.navigate(['/']),
        error: (err) => console.error('Error creating event:', err),
      });
    }
  }
}
