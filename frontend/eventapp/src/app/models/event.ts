export class Event{
    id: number;
    title: string;
    description: string;
    date: string;
    //time: string;
    location: string;
    image: string;
    quota: number;
    constructor(id: number, title: string, description: string, date: string,time: string ,location: string, image: string, quota: number){
        this.id = id;
        this.title = title;
        this.description = description;
        this.date = date;
     //   this.time = time;
        this.location = location;
        this.image = image;
        this.quota = quota;
    }
}