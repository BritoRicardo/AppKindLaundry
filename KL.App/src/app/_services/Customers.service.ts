import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customers } from '../_models/Customers';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {
  baseUrl = 'http://localhost:5000/api/customers';

  constructor(private http: HttpClient) { }

  public getAllCustomers() : Observable<Customers[]> {
    return this.http.get<Customers[]>(this.baseUrl);
  }

  public getCustomerByName(name : string) : Observable<Customers> {
    // url using template string
    return this.http.get<Customers>(`${this.baseUrl}/getByName/${name}`);
  }

  public getCustomerById(CustomersId : number) : Observable<Customers> {
    return this.http.get<Customers>(`${this.baseUrl}/${CustomersId}`);
  }

  public postCustomer(customer: Customers){
    return this.http.post<Customers>(this.baseUrl, customer);
  }

  public putCustomer(customer: Customers){
    return this.http.put<Customers>(`${this.baseUrl}/${customer.id}`, customer);
  }

  public deleteCustomer(id: number){
    return this.http.delete<Customers>(`${this.baseUrl}/${id}`);
  }
}
