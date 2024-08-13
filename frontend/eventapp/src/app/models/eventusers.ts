import { User } from "./user";

export class EventUser{
    id: number;
    event: Event;
    users: User[];
    constructor(id: number, event: Event, users: User[]){
        this.id = id;
        this.event = event;
        this.users = users;
    }
}