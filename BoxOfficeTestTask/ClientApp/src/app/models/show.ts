import { Session } from "./session";

export class Show {
    id: number;
    name: string;
    description: string;
    minAge: number;
    sessions: Session[];
    durationInMinutes: number;
}