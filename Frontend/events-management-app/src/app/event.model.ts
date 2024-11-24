export interface Event {
    eventId: string; 
    name?: string; 
    description?: string;
    startDate: Date;
    endDate: Date;
    location?: string;
    capacity: number;
}  