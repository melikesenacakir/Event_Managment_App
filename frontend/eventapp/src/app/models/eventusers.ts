export class EventUser{
    id: number;
    eventID: number;
    eventName: string;
    userName: string;
    userID : number;
    userSurname: string;
    quota: number;
    constructor(id: number, event: string, userName: string, userSurname: string,eventID: number,quota: number, userID: number){
        this.id = id;
        this.eventName = event;
        this.userName = userName;
        this.userSurname = userSurname;
        this.eventID = eventID;
        this.quota = quota;
        this.userID = userID;
    }
}