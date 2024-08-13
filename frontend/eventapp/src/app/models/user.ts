export class User{
    id: number;
    name: string;
    surname: string;
    username: string;
    password: string;
    email: string;
    constructor(id: number, username: string, password: string, email: string, name: string, surname: string){
        this.id = id;
        this.username = username;
        this.password = password;
        this.email = email;
        this.name = name;
        this.surname = surname;
    }
}