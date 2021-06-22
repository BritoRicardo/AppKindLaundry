import { Customers } from "./Customers";

export interface ScheduleService {
    id: number;
    price: string; 
    contractDate: string; 
    deliveryDate: string;  
    updateDate: string;  
    CustomersId: number;    
    Customers: Customers;
}
