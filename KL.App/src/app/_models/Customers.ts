import { ScheduleService } from "./ScheduleService";

export interface Customers {

    id: number;
    name: string;
    codArea1: number;
    phoneNumber1: number;
    codArea2: number;
    phoneNumber2: number; 
    email: string; 
    adress: string; 
    number: string;
    neighborhood: string;
    city: string; 
    alphaCode: string; 
    updateDate: Date;  
    birthDate: Date;
    schedulesServices: ScheduleService[];    
}
