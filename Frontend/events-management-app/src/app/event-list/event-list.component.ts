import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EventService } from '../event.service';
import { Event } from '../event.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-event-list',   

  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="container">
      <button class="create-btn" (click)="createEvent()">Create Event</button>
      <div class="event-grid">
        <div class="event-card" *ngFor="let event of events">
          <h2>{{ event.name }}</h2>
          <p>{{ event.description }}</p>
          <p><strong>Start:</strong> {{ event.startDate | date:'short' }}</p>
          <p><strong>End:</strong> {{ event.endDate | date:'short' }}</p>
          <p><strong>Location:</strong> {{ event.location }}</p>
          <div class="actions">
            <button (click)="editEvent(event)">Edit</button>
            <button (click)="deleteEvent(event.eventId)">Delete</button>
          </div>
        </div>
      </div>
    </div>
  `,
  styles: [`
    .container {
      padding: 20px;
    }

    .create-btn {
      padding: 10px 20px;
      margin-bottom: 20px;
      font-size: 16px;
      background-color: #007BFF;
      color: white;
      border: none;
      cursor: pointer;
    }

    .event-grid {
      display: grid;
      grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
      gap: 20px;
      padding: 10px 0;
    }

    .event-card {
      border: 1px solid #ddd;
      padding: 20px;
      background-color: #f9f9f9;
      border-radius: 8px;
      box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    }

    .actions {
      display: flex;
      justify-content: space-between;
      margin-top: 10px;
    }

    .actions button {
      padding: 5px 10px;
      cursor: pointer;
      font-size: 14px;
      border: none;
      background-color: #007BFF;
      color: white;
      border-radius: 5px;
    }

    .actions button:nth-child(2) {
      background-color: #dc3545; /* Red for delete */
    }
  `]
})
export class EventListComponent implements OnInit {
  events: Event[] = [];

  constructor(private eventService: EventService, private router: Router) {}

  ngOnInit():   
 void {
    this.eventService.getAllEvents().subscribe(   

      (data) => {
        console.log('Events received:', data);
        this.events = data;
      },
      (error) => {
        console.error('Error while fetching events:', error);
      }
    );
  }

  createEvent(): void {
    this.router.navigate(['/event-form']);
  }

  editEvent(event: Event): void {
    this.router.navigate(['/event-form', event.eventId]);
  }

  deleteEvent(eventId: string): void {
    this.eventService.deleteEvent(eventId).subscribe(
      () => {
        console.log('Event deleted successfully');
        this.events = this.events.filter(event => event.eventId !== eventId);
      },
      (error) => {
        console.error('Error deleting event:', error);
      }
    );
  }
}