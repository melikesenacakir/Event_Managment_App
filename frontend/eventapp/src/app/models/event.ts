export class Event{
    id: number;
    title: string;
    description: string;
    date: string;
    location: string;
    image: string;
    quota: number;
    constructor(id: number, title: string, description: string, date: string, location: string, image: string, quota: number){
        this.id = id;
        this.title = title;
        this.description = description;
        this.date = date;
        this.location = location;
        this.image = image;
        this.quota = quota;
    }
}